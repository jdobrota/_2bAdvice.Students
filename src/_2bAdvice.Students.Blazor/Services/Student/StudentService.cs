using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Services.Student;

public class StudentService : BaseHttpService, IStudentService
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly IClient? _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentService" /> class.
    /// </summary>
    /// <param name="httpClient">
    /// The HTTP client.
    /// </param>
    public StudentService(IClient httpClient)
    {
        this._httpClient = httpClient;
    }

    /// <summary>
    /// Deletes the student asynchronous.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <returns>
    /// Task&lt;Response&lt;int&gt;&gt;<br /></returns>
    public async Task<Response<int>> DeleteStudentAsync(Guid id)
    {
        Response<int> response = new();

        try
        {
            await this._httpClient!.StudentsDELETEAsync(id);
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<int>(ex);
        }

        return response;
    }

    /// <summary>
    /// Gets the students asynchronous.
    /// </summary>
    /// <returns>
    /// Task&lt;Response&lt;List&lt;StudentDto&gt;&gt;&gt;<br /></returns>
    public async Task<Response<List<StudentDto>>> GetStudentsAsync(string parameters)
    {
        Response<List<StudentDto>> response;

        try
        {
            var data = await this._httpClient!.StudentsAllAsync(parameters);
            response = new Response<List<StudentDto>> { Data = data.ToList(), Success = true };
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<List<StudentDto>>(ex);
        }

        return response;
    }

    /// <summary>
    /// Posts the student asynchronous.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    /// <returns>
    /// Task&lt;Response&lt;int&gt;&gt;<br /></returns>
    public async Task<Response<int>> PostStudentAsync(CreateStudentDto student)
    {
        Response<int> response = new();

        try
        {
            await this._httpClient!.StudentsPOSTAsync(student);
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<int>(ex);
        }

        return response;
    }

    /// <summary>
    /// Puts the student asynchronous.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    /// <returns>
    /// Task&lt;Response&lt;int&gt;&gt;<br /></returns>
    public async Task<Response<int>> PutStudentAsync(UpdateStudentDto student)
    {
        Response<int> response = new();

        try
        {
            await this._httpClient!.StudentsPUTAsync(student.Id, student);
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<int>(ex);
        }

        return response;
    }
}
