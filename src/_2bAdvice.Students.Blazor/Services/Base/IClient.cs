using System.Net.Http;

namespace _2bAdvice.Students.Blazor.Services.Base;

public partial interface IClient
{
    /// <summary>
    /// Gets the HTTP client.
    /// </summary>
    /// <value>
    /// The HTTP client.
    /// </value>
    public HttpClient HttpClient { get; }
}
