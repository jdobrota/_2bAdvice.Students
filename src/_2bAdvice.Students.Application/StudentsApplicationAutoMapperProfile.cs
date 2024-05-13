using System;
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
        this.CreateMap<Student, StudentDto>()
            .ForMember(member => member.LastModificationTime, map => map.Ignore())
            .ForMember(member => member.LastModifierId, map => map.Ignore())
            .ForMember(member => member.CreationTime, map => map.Ignore())
            .ForMember(member => member.CreatorId, map => map.Ignore())
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue))
            );

        this.CreateMap<CreateUpdateStudentDto, Student>()
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth))
            );
    }
}
