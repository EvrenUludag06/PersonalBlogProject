using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.ExperiencesDtos
{
    public class ExperiencesDto : DtoGetBase
    {
        public Experiences Experiences { get; set; }
    }
}
