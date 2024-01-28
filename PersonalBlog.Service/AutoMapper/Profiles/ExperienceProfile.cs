using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ExperiencesDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<ExperiencesAddDto, Experiences>().ForMember(des => des.CreatedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ExperiencesUpdateDto, Experiences>().ForMember(des => des.ModifiedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Experiences, ExperiencesUpdateDto>();
        }
    }
}
