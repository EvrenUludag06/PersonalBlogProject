using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SummaryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class SummaryProfile : Profile
    {
        public SummaryProfile()
        {
            CreateMap<SummaryUpdateDto, Summary>().ForMember(des => des.ModifiedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Summary, SummaryUpdateDto>();
        }
    }
}
