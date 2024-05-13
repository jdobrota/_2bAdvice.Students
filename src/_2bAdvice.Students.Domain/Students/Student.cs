using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Students;

public class Student : AggregateRoot<Guid>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public StudyTypeEnum TypeOfStudy { get; set; }

    public DateOnly DateOfBirth { get; set; }
}
