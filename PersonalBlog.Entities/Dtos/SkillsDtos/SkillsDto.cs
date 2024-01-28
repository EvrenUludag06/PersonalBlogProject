using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SkillsDtos
{
    public class SkillsDto : DtoGetBase
    {
        public Skills Skills { get; set; }
    }
}
