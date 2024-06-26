using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenIddict.Validation.AspNetCore;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using _2bAdvice.Students.Configurations;
using _2bAdvice.Students.EntityFrameworkCore;
using _2bAdvice.Students.MultiTenancy;

namespace _2bAdvice.Students;

[DependsOn(
    typeof(StudentsHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(StudentsApplicationModule),
    typeof(StudentsEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class StudentsHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        this.PreConfigure<OpenIddictBuilder>(builder =>
            builder.AddValidation(options =>
            {
                options.AddAudiences("Students");
                options.UseLocalServer();
                options.UseAspNetCore();
            })
        );
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        this.ConfigureAuthentication(context);
        this.ConfigureBundles();
        this.ConfigureUrls(configuration);
        this.ConfigureVirtualFileSystem(context);
        this.ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        this.ConfigureOData(context);
    }

    private void ConfigureOData(ServiceConfigurationContext context)
    {
        context
            .Services.AddControllers()
            .AddOData(opt => opt.Select().Filter().Count().OrderBy().Expand());
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context)
    {
        context.Services.ForwardIdentityAuthenticationForBearer(
            OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme
        );
        context.Services.Configure<AbpClaimsPrincipalFactoryOptions>(options =>
            options.IsDynamicClaimsEnabled = true
        );
    }

    private void ConfigureBundles()
    {
        this.Configure<AbpBundlingOptions>(options =>
            options.StyleBundles.Configure(
                LeptonXLiteThemeBundles.Styles.Global,
                bundle => bundle.AddFiles("/global-styles.css")
            )
        );
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        this.Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            options.RedirectAllowedUrls.AddRange(
                configuration["App:RedirectAllowedUrls"]?.Split(',') ?? Array.Empty<string>()
            );

            options.Applications["Angular"].RootUrl = configuration["App:ClientUrl"];
            options.Applications["Angular"].Urls[AccountUrlNames.PasswordReset] =
                "account/reset-password";
        });
    }

    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            this.Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<StudentsDomainSharedModule>(
                    Path.Combine(
                        hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}_2bAdvice.Students.Domain.Shared"
                    )
                );
                options.FileSets.ReplaceEmbeddedByPhysical<StudentsDomainModule>(
                    Path.Combine(
                        hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}_2bAdvice.Students.Domain"
                    )
                );
                options.FileSets.ReplaceEmbeddedByPhysical<StudentsApplicationContractsModule>(
                    Path.Combine(
                        hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}_2bAdvice.Students.Application.Contracts"
                    )
                );
                options.FileSets.ReplaceEmbeddedByPhysical<StudentsApplicationModule>(
                    Path.Combine(
                        hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}_2bAdvice.Students.Application"
                    )
                );
            });
        }
    }

    private static void ConfigureSwaggerServices(
        ServiceConfigurationContext context,
        IConfiguration configuration
    )
    {
        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"]!,
            new Dictionary<string, string> { { "Students", "Students API" } },
            options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo { Title = "Students API", Version = "v1" }
                );
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );
    }

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            ?.Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
            )
        );
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }
        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Students API");

            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            c.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            c.OAuthScopes("Students");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
