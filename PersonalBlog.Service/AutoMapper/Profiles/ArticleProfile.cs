using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticlesAddDto, Articles>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ArticlesUpdateDto, Articles>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Articles, ArticlesUpdateDto>();
        }
    }
}
