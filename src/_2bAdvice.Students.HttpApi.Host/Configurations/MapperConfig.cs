using _2bAdvice.Students.Students;
using AutoMapper;
using System;
using Volo.Abp.AutoMapper;

namespace _2bAdvice.Students.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {
            CreateMap<Student, StudentDto>().
                ForMember(member => member.LastModificationTime, map => map.Ignore()).
                ForMember(member => member.LastModifierId, map => map.Ignore()).
                ForMember(member => member.CreationTime, map => map.Ignore()).
                ForMember(member => member.CreatorId, map => map.Ignore()).
                ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue)));

            //CreateMap<Student, CreateUpdateStudentDto>();
        }
    }
}
