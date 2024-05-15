using System.Net.Http;

namespace _2bAdvice.Students.Blazor.Services.Base;

public partial class Client : IClient
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Client" /> class.
    /// </summary>
    /// <param name="httpClient">
    /// The HTTP client.
    /// </param>
    public Client(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    /// <summary>
    /// Gets the HTTP client.
    /// </summary>
    /// <value>
    /// The HTTP client.
    /// </value>
    public HttpClient HttpClient => this._httpClient;
}
