using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace _2bAdvice.Students;

[DependsOn(
    typeof(StudentsDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(StudentsApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
)]
[DependsOn(typeof(AbpAutoMapperModule))]
public class StudentsApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<StudentsApplicationModule>();

        this.Configure<AbpAutoMapperOptions>(options =>
            options.AddMaps<StudentsApplicationModule>(validate: true)
        );
    }
}
