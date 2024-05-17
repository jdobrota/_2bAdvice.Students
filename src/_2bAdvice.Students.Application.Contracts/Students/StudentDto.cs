using System;
using Volo.Abp.Application.Dtos;
using _2bAdvice.Students.Schools;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Students;

public class StudentDto : AuditedEntityDto<Guid>
{
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the type of study.
    /// </summary>
    /// <value>
    /// The type of study.
    /// </value>
    public StudyTypeEnum TypeOfStudy { get; set; }

    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    /// <value>
    /// The date of birth.
    /// </value>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the school identifier.
    /// </summary>
    /// <value>
    /// The school identifier.
    /// </value>
    public Guid SchoolId { get; set; }

    /// <summary>
    /// Gets or sets the name of the school.
    /// </summary>
    /// <value>
    /// The name of the school.
    /// </value>
    public SchoolDto? School { get; set; }
}
