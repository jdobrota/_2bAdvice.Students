using System;
using AutoMapper;
using Volo.Abp.AutoMapper;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students.Configurations;

public class MapperConfig : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MapperConfig" /> class.
    /// </summary>
    public MapperConfig()
    {
        this.CreateMap<Student, StudentDto>()
            .ForMember(member => member.LastModificationTime, map => map.Ignore())
            .ForMember(member => member.LastModifierId, map => map.Ignore())
            .ForMember(member => member.CreationTime, map => map.Ignore())
            .ForMember(member => member.CreatorId, map => map.Ignore())
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue))
            );
    }
}
