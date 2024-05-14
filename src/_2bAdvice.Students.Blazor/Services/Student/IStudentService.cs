using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Services.Student;

public interface IStudentService
{
    Task<Response<List<StudentDto>>> GetStudentsAsync();
    Task<Response<int>> PostStudentAsync(CreateStudentDto body);
    Task<Response<int>> DeleteStudentAsync(Guid id);
    Task<Response<int>> PutStudentAsync(UpdateStudentDto student);
}
