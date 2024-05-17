using System;

namespace _2bAdvice.Students.Blazor.Services.Base;

public partial class UpdateStudentDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateStudentDto" /> class.
    /// </summary>
    public UpdateStudentDto()
    {
        this.DateOfBirth = DateTime.Now;
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.TypeOfStudy = StudyTypeEnum.INTERNAL;
    }
}
