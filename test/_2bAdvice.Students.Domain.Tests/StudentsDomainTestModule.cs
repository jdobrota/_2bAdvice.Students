using Volo.Abp.Modularity;

namespace _2bAdvice.Students;

[DependsOn(
    typeof(StudentsDomainModule),
    typeof(StudentsTestBaseModule)
)]
public class StudentsDomainTestModule : AbpModule
{

}
