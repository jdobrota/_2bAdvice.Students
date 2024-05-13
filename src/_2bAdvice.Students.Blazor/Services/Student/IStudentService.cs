using System.Collections.Generic;
using System.Threading.Tasks;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Services.Student;

public interface IStudentService
{
    Task<Response<List<StudentDto>>> GetStudentsAsync();
    Task<Response<int>> PostStudentAsync(CreateUpdateStudentDto body);
}
