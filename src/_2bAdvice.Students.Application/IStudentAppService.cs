﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

public interface IStudentsAppService : IApplicationService
{
    Task<List<StudentDto>> GetStudentsDtoAsync();
    Task<Student> AddStudentAsync(CreateUpdateStudentDto studentDto);
}