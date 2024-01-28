using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.ArticleDtos
{
    public class ArticlesListDto : DtoGetBase
    {
        public IList<Articles> Articles { get; set; }
    }
}
