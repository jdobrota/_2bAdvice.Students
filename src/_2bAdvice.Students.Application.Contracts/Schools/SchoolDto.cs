using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students.Schools;

public class SchoolDto : AuditedEntityDto<Guid>
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the type of school.
    /// </summary>
    /// <value>
    /// The type of school.
    /// </value>
    public SchoolTypeEnum TypeOfSchool { get; set; }

    [JsonIgnore]
    /// <summary>
    /// Gets or sets the students.
    /// </summary>
    /// <value>
    /// The students.
    /// </value>
    public virtual List<StudentDto>? Students { get; set; }
}
