using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace _2bAdvice.Students.Data;

public class StudentsDbMigrationService : ITransientDependency
{
    public ILogger<StudentsDbMigrationService> Logger { get; set; }

    private readonly IDataSeeder _dataSeeder;
    private readonly IEnumerable<IStudentsDbSchemaMigrator> _dbSchemaMigrators;
    private readonly ITenantRepository _tenantRepository;
    private readonly ICurrentTenant _currentTenant;

    public StudentsDbMigrationService(
        IDataSeeder dataSeeder,
        IEnumerable<IStudentsDbSchemaMigrator> dbSchemaMigrators,
        ITenantRepository tenantRepository,
        ICurrentTenant currentTenant
    )
    {
        this._dataSeeder = dataSeeder;
        this._dbSchemaMigrators = dbSchemaMigrators;
        this._tenantRepository = tenantRepository;
        this._currentTenant = currentTenant;

        this.Logger = NullLogger<StudentsDbMigrationService>.Instance;
    }

    public async Task MigrateAsync()
    {
        var initialMigrationAdded = this.AddInitialMigrationIfNotExist();

        if (initialMigrationAdded)
        {
            return;
        }

        this.Logger.LogInformation("Started database migrations...");

        await this.MigrateDatabaseSchemaAsync();
        await this.SeedDataAsync();

        this.Logger.LogInformation($"Successfully completed host database migrations.");

        var tenants = await this._tenantRepository.GetListAsync(includeDetails: true);

        var migratedDatabaseSchemas = new HashSet<string>();
        foreach (var tenant in tenants)
        {
            using (this._currentTenant.Change(tenant.Id))
            {
                if (tenant.ConnectionStrings.Any())
                {
                    var tenantConnectionStrings = tenant
                        .ConnectionStrings.Select(x => x.Value)
                        .ToList();

                    if (!migratedDatabaseSchemas.IsSupersetOf(tenantConnectionStrings))
                    {
                        await this.MigrateDatabaseSchemaAsync(tenant);

                        migratedDatabaseSchemas.AddIfNotContains(tenantConnectionStrings);
                    }
                }

                await this.SeedDataAsync(tenant);
            }

            this.Logger.LogInformation(
                $"Successfully completed {tenant.Name} tenant database migrations."
            );
        }

        this.Logger.LogInformation("Successfully completed all database migrations.");
        this.Logger.LogInformation("You can safely end this process...");
    }

    private async Task MigrateDatabaseSchemaAsync(Tenant? tenant = null)
    {
        this.Logger.LogInformation(
            $"Migrating schema for {(tenant == null ? "host" : tenant.Name + " tenant")} database..."
        );

        foreach (var migrator in this._dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    private async Task SeedDataAsync(Tenant? tenant = null)
    {
        this.Logger.LogInformation(
            $"Executing {(tenant == null ? "host" : tenant.Name + " tenant")} database seed..."
        );

        await this._dataSeeder.SeedAsync(
            new DataSeedContext(tenant?.Id)
                .WithProperty(
                    IdentityDataSeedContributor.AdminEmailPropertyName,
                    IdentityDataSeedContributor.AdminEmailDefaultValue
                )
                .WithProperty(
                    IdentityDataSeedContributor.AdminPasswordPropertyName,
                    IdentityDataSeedContributor.AdminPasswordDefaultValue
                )
        );
    }

    private bool AddInitialMigrationIfNotExist()
    {
        try
        {
            if (!this.DbMigrationsProjectExists())
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

        try
        {
            if (!this.MigrationsFolderExists())
            {
                this.AddInitialMigration();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            this.Logger.LogWarning("Couldn't determinate if any migrations exist : " + e.Message);
            return false;
        }
    }

    private bool DbMigrationsProjectExists()
    {
        var dbMigrationsProjectFolder = this.GetEntityFrameworkCoreProjectFolderPath();

        return dbMigrationsProjectFolder != null;
    }

    private bool MigrationsFolderExists()
    {
        var dbMigrationsProjectFolder = this.GetEntityFrameworkCoreProjectFolderPath();
        return dbMigrationsProjectFolder != null
            && Directory.Exists(Path.Combine(dbMigrationsProjectFolder, "Migrations"));
    }

    private void AddInitialMigration()
    {
        this.Logger.LogInformation("Creating initial migration...");

        string argumentPrefix;
        string fileName;

        if (
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
            || RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
        )
        {
            argumentPrefix = "-c";
            fileName = "/bin/bash";
        }
        else
        {
            argumentPrefix = "/C";
            fileName = "cmd.exe";
        }

        var procStartInfo = new ProcessStartInfo(
            fileName,
            $"{argumentPrefix} \"abp create-migration-and-run-migrator \"{this.GetEntityFrameworkCoreProjectFolderPath()}\"\""
        );

        try
        {
            Process.Start(procStartInfo);
        }
        catch (Exception)
        {
            throw new Exception("Couldn't run ABP CLI...");
        }
    }

    private string? GetEntityFrameworkCoreProjectFolderPath()
    {
        var slnDirectoryPath = this.GetSolutionDirectoryPath();

        if (slnDirectoryPath == null)
        {
            throw new Exception("Solution folder not found!");
        }

        var srcDirectoryPath = Path.Combine(slnDirectoryPath, "src");

        return Directory
            .GetDirectories(srcDirectoryPath)
            .FirstOrDefault(d => d.EndsWith(".EntityFrameworkCore"));
    }

    private string? GetSolutionDirectoryPath()
    {
        var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (currentDirectory != null && Directory.GetParent(currentDirectory.FullName) != null)
        {
            currentDirectory = Directory.GetParent(currentDirectory.FullName);

            if (
                currentDirectory != null
                && Directory
                    .GetFiles(currentDirectory.FullName)
                    .FirstOrDefault(f => f.EndsWith(".sln")) != null
            )
            {
                return currentDirectory.FullName;
            }
        }

        return null;
    }
}
