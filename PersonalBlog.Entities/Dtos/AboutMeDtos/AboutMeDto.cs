using PersonalBlog.Shared.Entities.Abstract;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using PersonalBlog.Shared.Utilities.ComplexTypes;

namespace PersonalBlog.Entities.Dtos.AboutMeDtos
{
    public class AboutMeDto : DtoGetBase
    {
        public AboutMe  AboutMe { get; set; }
    }
}
