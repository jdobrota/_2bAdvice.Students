using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Schools;

public class CreateSchoolDto
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    [Required]
    [StringLength(200)]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the type of school.
    /// </summary>
    /// <value>
    /// The type of school.
    /// </value>
    [Required]
    public SchoolTypeEnum TypeOfSchool { get; set; }
}
