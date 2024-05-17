using System;

namespace _2bAdvice.Students.Blazor.Services.Base;

public partial class UpdateSchoolDto
{
    public UpdateSchoolDto()
    {
        this.Name = string.Empty;
        this.Address = string.Empty;
        this.TypeOfSchool = SchoolTypeEnum.PUBLIC;
        this.Id = Guid.Empty;
    }
}
