using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace _2bAdvice.Students.Data;

/* This is used if database provider does't define
 * IStudentsDbSchemaMigrator implementation.
 */
public class NullStudentsDbSchemaMigrator : IStudentsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
