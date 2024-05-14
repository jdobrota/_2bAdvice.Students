﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _2bAdvice.Students.Shared;

namespace _2bAdvice.Students.Students;

public class UpdateStudentDto : BaseDTO
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public StudyTypeEnum TypeOfStudy { get; set; } = StudyTypeEnum.INTERNAL;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}