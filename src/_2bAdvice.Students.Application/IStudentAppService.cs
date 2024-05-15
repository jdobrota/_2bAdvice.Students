using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

public interface IStudentsAppService : IApplicationService
{
    /// <summary>
    /// Gets the students dto asynchronous.
    /// </summary>
    /// <returns>
    /// Task&lt;List&lt;StudentDto&gt;&gt;<br /></returns>
    Task<List<StudentDto>> GetStudentsDtoAsync();

    /// <summary>
    /// Adds the student asynchronous.
    /// </summary>
    /// <param name="studentDto">
    /// The student dto.
    /// </param>
    /// <returns>
    /// Task&lt;Student&gt;<br /></returns>
    Task<Student> AddStudentAsync(CreateStudentDto studentDto);

    /// <summary>
    /// Deletes the student asynchronous.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <returns>
    /// Task&lt;bool&gt;<br /></returns>
    Task<bool> DeleteStudentAsync(Guid id);

    /// <summary>
    /// Puts the student asynchronous.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <param name="studentDto">
    /// The student dto.
    /// </param>
    /// <returns>
    /// Task&lt;bool&gt;<br /></returns>
    Task<bool> PutStudentAsync(Guid id, UpdateStudentDto studentDto);
}
