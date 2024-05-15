namespace _2bAdvice.Students.Blazor.Services.Base;

public class Response<T>
{
    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    /// <value>
    /// The message.
    /// </value>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the validation errors.
    /// </summary>
    /// <value>
    /// The validation errors.
    /// </value>
    public string? ValidationErrors { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Response{T}" /> is success.
    /// </summary>
    /// <value>
    ///   <c>true</c> if success; otherwise, <c>false</c>.
    /// </value>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public T? Data { get; set; }
}
