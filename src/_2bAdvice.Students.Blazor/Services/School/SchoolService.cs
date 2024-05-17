using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Services.School;

public class SchoolService : BaseHttpService, ISchoolService
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly IClient? _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="SchoolService" /> class.
    /// </summary>
    /// <param name="httpClient">
    /// The HTTP client.
    /// </param>
    public SchoolService(IClient httpClient)
    {
        this._httpClient = httpClient;
    }

    /// <summary>
    /// Deletes the school asynchronous.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <returns>
    /// Task&lt;Response&lt;int&gt;&gt;<br /></returns>
    public async Task<Response<int>> DeleteSchoolAsync(Guid id)
    {
        Response<int> response = new();

        try
        {
            await this._httpClient!.SchoolsDELETEAsync(id);
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<int>(ex);
        }

        return response;
    }

    /// <summary>
    /// Gets the schools asynchronous.
    /// </summary>
    /// <returns>
    /// Task&lt;Response&lt;List&lt;SchoolDto&gt;&gt;&gt;<br /></returns>
    public async Task<Response<List<SchoolDto>>> GetSchoolsAsync(string? parameters)
    {
        Response<List<SchoolDto>> response;

        try
        {
            var data = await this._httpClient!.SchoolsAllAsync();
            response = new Response<List<SchoolDto>> { Data = data.ToList(), Success = true };
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<List<SchoolDto>>(ex);
        }

        return response;
    }

    /// <summary>
    /// Posts the school asynchronous.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    /// <returns>
    /// Task&lt;Response&lt;int&gt;&gt;<br /></returns>
    public async Task<Response<int>> PostSchoolAsync(CreateSchoolDto school)
    {
        Response<int> response = new();

        try
        {
            await this._httpClient!.SchoolsPOSTAsync(school);
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<int>(ex);
        }

        return response;
    }

    /// <summary>
    /// Puts the school asynchronous.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    /// <returns>
    /// Task&lt;Response&lt;int&gt;&gt;<br /></returns>
    public async Task<Response<int>> PutSchoolAsync(UpdateSchoolDto school)
    {
        Response<int> response = new();

        try
        {
            await this._httpClient!.SchoolsPUTAsync(school.Id, school);
        }
        catch (ApiException ex)
        {
            response = this.ConvertApiExceptions<int>(ex);
        }

        return response;
    }
}
