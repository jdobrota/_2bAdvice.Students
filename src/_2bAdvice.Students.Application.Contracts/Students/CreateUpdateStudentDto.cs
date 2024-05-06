using System;
using System.ComponentModel.DataAnnotations;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Students
{
    public class CreateUpdateStudentDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public StudyTypeEnum TypeOfStudy { get; set; } = StudyTypeEnum.INTERNAL;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
