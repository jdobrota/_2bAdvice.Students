using System.Net.Http;

namespace _2bAdvice.Students.Blazor.Services.Base;

public partial interface IClient
{
    public HttpClient HttpClient { get; }
}
