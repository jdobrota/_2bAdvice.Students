using AutoMapper;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

public class StudentsApplicationAutoMapperProfile : Profile
{
    public StudentsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Student, StudentDto>();
        CreateMap<CreateUpdateStudentDto, Student>();
    }
}
