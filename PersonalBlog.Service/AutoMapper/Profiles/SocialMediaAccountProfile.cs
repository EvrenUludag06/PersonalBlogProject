using AutoMapper;
using PersonalBlog.Entities.Dtos.SocialMediaAccountDtos;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class SocialMediaAccountProfile : Profile
    {
        public SocialMediaAccountProfile()
        {
            CreateMap<AccountsAddDto, SocialMediaAccounts>().ForMember(des => des.CreatedTime,opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<AccountsUpdateDto, SocialMediaAccounts>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SocialMediaAccounts, AccountsUpdateDto>();
        }
    }
}
