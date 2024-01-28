using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SkilslDtos
{
    public class SkillsListDto : DtoGetBase
    {
        public IList<Skills> Skills { get; set; }
    }
}
