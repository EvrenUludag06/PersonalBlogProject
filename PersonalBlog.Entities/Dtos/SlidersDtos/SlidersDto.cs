using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SliderDtos
{
    public class SlidersDto : DtoGetBase
    {
        public HomePageSliders Sliders { get; set; }
    }
}
