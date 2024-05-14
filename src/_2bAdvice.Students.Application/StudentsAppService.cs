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

    public async Task<Student> AddStudentAsync(CreateStudentDto studentDto)
    {
        var student = this.ObjectMapper.Map<CreateStudentDto, Student>(studentDto);
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

    public async Task<bool> DeleteStudentAsync(Guid id)
    {
        var student = await this._studentRepository!.GetAsync(s => s.Id == id);
        if (student == null)
        {
            return false;
        }

        await this._studentRepository!.DeleteAsync(student.Id);
        return true;
    }

    public async Task<bool> PutStudentAsync(Guid id, UpdateStudentDto studentDto)
    {
        var student = await this._studentRepository!.GetAsync(s => s.Id == id);
        if (student == null)
        {
            return false;
        }

        this.ObjectMapper.Map(studentDto, student);

        await this._studentRepository!.UpdateAsync(student);
        return true;
    }
}
