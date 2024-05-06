using System;
using Volo.Abp.Domain.Entities.Auditing;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Students
{
    public class Student : AuditedAggregateRoot<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public StudyTypeEnum TypeOfStudy { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
