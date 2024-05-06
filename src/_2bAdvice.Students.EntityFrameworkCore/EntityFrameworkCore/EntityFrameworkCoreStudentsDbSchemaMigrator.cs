using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _2bAdvice.Students.Data;
using Volo.Abp.DependencyInjection;

namespace _2bAdvice.Students.EntityFrameworkCore;

public class EntityFrameworkCoreStudentsDbSchemaMigrator
    : IStudentsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreStudentsDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the StudentsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<StudentsDbContext>()
            .Database
            .MigrateAsync();
    }
}
