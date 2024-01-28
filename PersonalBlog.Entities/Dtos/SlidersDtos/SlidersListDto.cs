using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SliderDtos
{
    public class SlidersListDto : DtoGetBase
    {
        public IList<HomePageSliders> Sliders { get; set; }
    }
}
