﻿using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SummaryDtos
{
    public class SummaryDto : DtoGetBase
    {
        public Summary Summary { get; set; }
    }
}
