using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SiteIdentityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class SiteIdentityProfile : Profile
    {
        public SiteIdentityProfile()
        {
            CreateMap<SiteIdentityUpdateDto, SiteIdentity>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SiteIdentity, SiteIdentityUpdateDto>();
        }
    }
}
