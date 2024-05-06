using System;
using Volo.Abp.Application.Dtos;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Students
{
    public class StudentDto : AuditedEntityDto<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public StudyTypeEnum TypeOfStudy { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
