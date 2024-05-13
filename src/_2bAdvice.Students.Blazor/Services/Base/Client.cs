using System.Net.Http;

namespace _2bAdvice.Students.Blazor.Services.Base;

public partial class Client : IClient
{
    public Client(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public HttpClient HttpClient => this._httpClient;
}
