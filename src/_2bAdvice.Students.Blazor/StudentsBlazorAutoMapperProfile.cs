using AutoMapper;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor;

public class StudentsBlazorAutoMapperProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StudentsBlazorAutoMapperProfile" /> class.
    /// </summary>
    public StudentsBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.
        this.CreateMap<StudentDto, UpdateStudentDto>();
        this.CreateMap<UpdateStudentDto, CreateStudentDto>();
    }
}
