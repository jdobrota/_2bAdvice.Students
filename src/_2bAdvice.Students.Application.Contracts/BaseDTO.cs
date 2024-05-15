using System;
using System.Collections.Generic;
using System.Text;

namespace _2bAdvice.Students;

public abstract class BaseDTO
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }
}
