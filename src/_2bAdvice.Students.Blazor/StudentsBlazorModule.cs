using System;
using System.Net.Http;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using Volo.Abp.AspNetCore.Components.Web.LeptonXLiteTheme.Themes.LeptonXLite;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.WebAssembly.LeptonXLiteTheme;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Blazor.WebAssembly;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.Blazor.WebAssembly;
using Volo.Abp.TenantManagement.Blazor.WebAssembly;
using Volo.Abp.UI.Navigation;
using _2bAdvice.Students.Blazor.Menus;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.School;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor;

[DependsOn(
    typeof(AbpAutofacWebAssemblyModule),
    typeof(StudentsHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyLeptonXLiteThemeModule),
    typeof(AbpIdentityBlazorWebAssemblyModule),
    typeof(AbpTenantManagementBlazorWebAssemblyModule),
    typeof(AbpSettingManagementBlazorWebAssemblyModule)
)]
public class StudentsBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
        var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

        ConfigureAuthentication(builder);
        ConfigureHttpClient(context, environment);
        this.ConfigureBlazorise(context);
        this.ConfigureRouter(context);
        ConfigureUI(builder);
        this.ConfigureMenu(context);
        this.ConfigureAutoMapper(context);

        context.Services.AddFluxor(config =>
            config.ScanAssemblies(typeof(StudentsBlazorModule).Assembly).UseReduxDevTools()
        );

        var remoteApi = builder.Configuration["RemoteServices:Default:BaseUrl"];

        context.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(remoteApi!) }); //"https://localhost:44318"

        context.Services.AddScoped<IClient, Client>();
        context.Services.AddScoped<IStudentService, StudentService>();
        context.Services.AddScoped<ISchoolService, SchoolService>();
    }

    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        this.Configure<AbpRouterOptions>(options =>
            options.AppAssembly = typeof(StudentsBlazorModule).Assembly
        );
    }

    private void ConfigureMenu(ServiceConfigurationContext context)
    {
        this.Configure<AbpNavigationOptions>(options =>
            options.MenuContributors.Add(
                new StudentsMenuContributor(context.Services.GetConfiguration())
            )
        );
    }

    private void ConfigureBlazorise(ServiceConfigurationContext context)
    {
        context.Services.AddBootstrap5Providers().AddFontAwesomeIcons();
    }

    private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
    {
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("AuthServer", options.ProviderOptions);
            options.UserOptions.NameClaim = OpenIddictConstants.Claims.Name;
            options.UserOptions.RoleClaim = OpenIddictConstants.Claims.Role;

            options.ProviderOptions.DefaultScopes.Add("Students");
            options.ProviderOptions.DefaultScopes.Add("roles");
            options.ProviderOptions.DefaultScopes.Add("email");
            options.ProviderOptions.DefaultScopes.Add("phone");
        });
    }

    private static void ConfigureUI(WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#ApplicationContainer");
        builder.RootComponents.Add<HeadOutlet>("head::after");
    }

    private static void ConfigureHttpClient(
        ServiceConfigurationContext context,
        IWebAssemblyHostEnvironment environment
    )
    {
        context.Services.AddTransient(sp => new HttpClient
        {
            BaseAddress = new Uri(environment.BaseAddress)
        });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        this.Configure<AbpAutoMapperOptions>(options => options.AddMaps<StudentsBlazorModule>());
    }
}
