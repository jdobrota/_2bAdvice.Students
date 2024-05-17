using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students.Schools;

public class School : AggregateRoot<Guid>
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

    /// <summary>
    /// Gets or sets the schools.
    /// </summary>
    /// <value>
    /// The schools.
    /// </value>
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
