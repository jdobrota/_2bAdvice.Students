using System;
using System.ComponentModel.DataAnnotations;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Students;

public class CreateStudentDto
{
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the type of study.
    /// </summary>
    /// <value>
    /// The type of study.
    /// </value>
    [Required]
    public StudyTypeEnum TypeOfStudy { get; set; } = StudyTypeEnum.INTERNAL;

    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    /// <value>
    /// The date of birth.
    /// </value>
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the school identifier.
    /// </summary>
    /// <value>
    /// The school identifier.
    /// </value>
    [Required]
    public Guid SchoolId { get; set; }
}
