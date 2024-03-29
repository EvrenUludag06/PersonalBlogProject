﻿using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.EducationDtos
{
    public class EducationDto : DtoGetBase
    {
        public Education Education { get; set; }
    }
}
