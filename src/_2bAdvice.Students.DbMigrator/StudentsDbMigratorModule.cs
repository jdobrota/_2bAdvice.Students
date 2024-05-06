using _2bAdvice.Students.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace _2bAdvice.Students.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StudentsEntityFrameworkCoreModule),
    typeof(StudentsApplicationContractsModule)
    )]
public class StudentsDbMigratorModule : AbpModule
{
}
