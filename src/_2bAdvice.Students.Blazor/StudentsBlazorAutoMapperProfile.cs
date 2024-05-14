using AutoMapper;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor;

public class StudentsBlazorAutoMapperProfile : Profile
{
    public StudentsBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.
        this.CreateMap<StudentDto, UpdateStudentDto>();
        this.CreateMap<UpdateStudentDto, CreateStudentDto>();
    }
}
