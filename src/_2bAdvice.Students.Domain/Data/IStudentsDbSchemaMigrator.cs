using System.Threading.Tasks;

namespace _2bAdvice.Students.Data;

public interface IStudentsDbSchemaMigrator
{
    Task MigrateAsync();
}
