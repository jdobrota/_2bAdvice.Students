using Volo.Abp.Modularity;

namespace _2bAdvice.Students;

public abstract class StudentsApplicationTestBase<TStartupModule> : StudentsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
