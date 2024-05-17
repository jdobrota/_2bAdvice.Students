using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Services.Student;

public interface IStudentService
{
    /// <summary>
    /// Gets the students asynchronous.
    /// </summary>
    /// <returns>
    ///   <br />
    /// </returns>
    Task<Response<List<StudentDto>>> GetStudentsAsync(string parameters);

    /// <summary>
    /// Posts the student asynchronous.
    /// </summary>
    /// <param name="body">
    /// The body.
    /// </param>
    /// <returns>
    ///   <br />
    /// </returns>
    Task<Response<int>> PostStudentAsync(CreateStudentDto body);

    /// <summary>
    /// Deletes the student asynchronous.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <returns>
    ///   <br />
    /// </returns>
    Task<Response<int>> DeleteStudentAsync(Guid id);

    /// <summary>
    /// Puts the student asynchronous.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    /// <returns>
    ///   <br />
    /// </returns>
    Task<Response<int>> PutStudentAsync(UpdateStudentDto student);
}
