using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using _2bAdvice.Students.Schools;

namespace _2bAdvice.Students;

public interface ISchoolsAppService : IApplicationService
{
    /// <summary>
    /// Gets the students dto asynchronous.
    /// </summary>
    /// <returns>
    /// Task&lt;List&lt;StudentDto&gt;&gt;<br /></returns>
    Task<List<SchoolDto>> GetSchoolsDtoAsync();

    /// <summary>
    /// Adds the student asynchronous.
    /// </summary>
    /// <param name="studentDto">
    /// The student dto.
    /// </param>
    /// <returns>
    /// Task&lt;Student&gt;<br /></returns>
    Task<School> AddSchoolAsync(CreateSchoolDto studentDto);

    /// <summary>
    /// Deletes the student asynchronous.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <returns>
    /// Task&lt;bool&gt;<br /></returns>
    Task<bool> DeleteSchoolAsync(Guid id);

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
    Task<bool> PutSchoolAsync(Guid id, UpdateSchoolDto schoolDto);
}
