﻿using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.CategoryDtos
{
    public class CategoryDto : DtoGetBase
    {
        public Categories Categories { get; set; }
    }
}
