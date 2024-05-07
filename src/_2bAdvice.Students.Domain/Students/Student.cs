using System;
using System.ComponentModel.DataAnnotations;
using _2bAdvice.Students.Shared;
using Volo.Abp.Domain.Entities;

namespace _2bAdvice.Students.Students
{
    public class Student : AggregateRoot<Guid>
    {
        [Key]
        public override Guid Id { get; protected set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public StudyTypeEnum TypeOfStudy { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
