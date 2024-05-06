using Volo.Abp.Modularity;

namespace _2bAdvice.Students;

/* Inherit from this class for your domain layer tests. */
public abstract class StudentsDomainTestBase<TStartupModule> : StudentsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
