using System;
using AutoMapper;
using _2bAdvice.Students.Schools;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

public class StudentsApplicationAutoMapperProfile : Profile
{
    public StudentsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        ///Students
        this.CreateMap<Student, StudentDto>()
            .ForMember(member => member.LastModificationTime, map => map.Ignore())
            .ForMember(member => member.LastModifierId, map => map.Ignore())
            .ForMember(member => member.CreationTime, map => map.Ignore())
            .ForMember(member => member.CreatorId, map => map.Ignore())
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue))
            );

        this.CreateMap<CreateStudentDto, Student>()
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.School, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth))
            );

        this.CreateMap<UpdateStudentDto, Student>()
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.School, opt => opt.Ignore())
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth))
            );

        ///Schools
        this.CreateMap<School, SchoolDto>()
            .ForMember(member => member.LastModificationTime, map => map.Ignore())
            .ForMember(member => member.LastModifierId, map => map.Ignore())
            .ForMember(member => member.CreationTime, map => map.Ignore())
            .ForMember(member => member.CreatorId, map => map.Ignore());

        this.CreateMap<CreateSchoolDto, School>()
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.Students, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        this.CreateMap<UpdateSchoolDto, School>()
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.Students, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore());
    }
}
