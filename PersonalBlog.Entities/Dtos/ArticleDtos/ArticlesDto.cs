using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.ArticleDtos
{
    public class ArticlesDto : DtoGetBase
    {
        public Articles Articles { get; set; }
    }
}
