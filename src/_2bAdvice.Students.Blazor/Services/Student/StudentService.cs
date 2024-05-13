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

    public async Task<Response<int>> PostStudentAsync(CreateUpdateStudentDto body)
    {
        Response<int> response = new();

        try
        {
            await this._httpClient!.StudentsAsync(body);
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<int>(ex);
        }

        return response;
    }
}
