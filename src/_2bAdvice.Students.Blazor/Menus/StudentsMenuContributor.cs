using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using _2bAdvice.Students.Localization;
using _2bAdvice.Students.MultiTenancy;

namespace _2bAdvice.Students.Blazor.Menus;

public class StudentsMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public StudentsMenuContributor(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await this.ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await this.ConfigureUserMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<StudentsResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(StudentsMenus.Home, l["Menu:Home"], "/", icon: "fas fa-home")
        );

        var administration = context.Menu.GetAdministration();

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                StudentsMenus.Schools,
                l["Menu:Schools"],
                "/Schools",
                icon: "fa fa-building"
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                StudentsMenus.Students,
                l["Menu:Students"],
                "/Students",
                icon: "fa fa-user"
            )
        );

        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();

        var authServerUrl = this._configuration["AuthServer:Authority"] ?? "";

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Account.Manage",
                accountStringLocalizer["MyAccount"],
                $"{authServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={this._configuration["App:SelfUrl"]}",
                icon: "fa fa-cog",
                order: 1000,
                null
            ).RequireAuthenticated()
        );

        return Task.CompletedTask;
    }
}
