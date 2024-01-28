using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SkillsDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<SkillsAddDto, Skills>().ForMember(des => des.CreatedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SkillsUpdateDto, Skills>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Skills, SkillsUpdateDto>();
        }
    }
}
