using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.CategoriesDtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Categories> Categories { get; set; }
    }
}
