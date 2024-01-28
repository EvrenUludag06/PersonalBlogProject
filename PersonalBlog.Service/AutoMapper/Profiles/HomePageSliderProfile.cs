using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SliderDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class HomePageSliderProfile : Profile
    {
        public HomePageSliderProfile()
        {
            CreateMap<SlidersAddDto, HomePageSliders>().ForMember(des => des.CreatedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SlidersUpdateDto, HomePageSliders>().ForMember(des => des.ModifiedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<HomePageSliders, SlidersUpdateDto>();
        }
    }
}
