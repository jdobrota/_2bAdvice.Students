using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace _2bAdvice.Students.Blazor.Services.Base;

public partial class BaseHttpService
{
    /// <summary>
    /// Converts the API exceptions.
    /// </summary>
    /// <typeparam name="Guid">
    /// The type of the uid.
    /// </typeparam>
    /// <param name="apiException">
    /// The API exception.
    /// </param>
    /// <returns>
    /// Response&lt;Guid&gt;
    /// </returns>
    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
    {
        if (apiException.StatusCode == 400)
        {
            return new Response<Guid>()
            {
                Message = "Validation errors occured.",
                ValidationErrors = apiException.Response,
                Success = false
            };
        }
        if (apiException.StatusCode == 404)
        {
            return new Response<Guid>()
            {
                Message = "The requested item could not be found.",
                Success = false
            };
        }
        if (apiException.StatusCode == 401)
        {
            return new Response<Guid>()
            {
                Message = "Invalid Credentials, Please try again",
                Success = false
            };
        }
        return ((apiException.StatusCode >= 200) && (apiException.StatusCode <= 299))
            ? new Response<Guid>() { Message = "Operation reported success", Success = true }
            : new Response<Guid>()
            {
                Message = "Something went wrong, please try again.",
                Success = false
            };
    }
}
