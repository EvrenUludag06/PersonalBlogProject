using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.InterestedsDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class InterestedProfile : Profile
    {
        public InterestedProfile()
        {
            CreateMap<InterestedsAddDto, Interesteds>().ForMember(des => des.CreatedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<InterestedsUpdateDto, Interesteds>().ForMember(des => des.ModifiedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Interesteds, InterestedsUpdateDto>();
        }
    }
}
