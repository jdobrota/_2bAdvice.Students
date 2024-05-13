using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using _2bAdvice.Students.Localization;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

/* Inherit your application services from this class.
 */
public class StudentsAppService : ApplicationService, IStudentsAppService
{
    private readonly IRepository<Student, Guid>? _studentRepository;

    /// <summary>Initializes a new instance of the <see cref="StudentsAppService" /> class.</summary>
    /// <param name="studentRepository">The student repository.</param>
    public StudentsAppService(IRepository<Student, Guid>? studentRepository)
    {
        this.LocalizationResource = typeof(StudentsResource);
        this._studentRepository = studentRepository;
    }

    public async Task<Student> AddStudentAsync(CreateUpdateStudentDto studentDto)
    {
        var student = this.ObjectMapper.Map<CreateUpdateStudentDto, Student>(studentDto);
        return await this._studentRepository!.InsertAsync(student);
    }

    /// <summary>
    /// Gets the students dto asynchronous.
    /// </summary>
    /// <returns>
    ///   <br />
    /// </returns>
    public async Task<List<StudentDto>> GetStudentsDtoAsync()
    {
        var students = await this._studentRepository!.GetListAsync();
        var studentDto = this.ObjectMapper.Map<List<Student>, List<StudentDto>>(students);
        return studentDto;
    }
}
