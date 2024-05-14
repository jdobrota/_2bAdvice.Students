using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Services.Student;

public class StudentService : BaseHttpService, IStudentService
{
    private readonly IClient? _httpClient;

    public StudentService(IClient httpClient)
    {
        this._httpClient = httpClient;
    }

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

    public async Task<Response<List<StudentDto>>> GetStudentsAsync()
    {
        Response<List<StudentDto>> response;

        try
        {
            var data = await this._httpClient!.StudentsAllAsync();
            response = new Response<List<StudentDto>> { Data = data.ToList(), Success = true };
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<List<StudentDto>>(ex);
        }

        return response;
    }

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
