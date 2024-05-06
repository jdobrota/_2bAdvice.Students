using Volo.Abp.Modularity;

namespace _2bAdvice.Students;

[DependsOn(
    typeof(StudentsApplicationModule),
    typeof(StudentsDomainTestModule)
)]
public class StudentsApplicationTestModule : AbpModule
{

}
