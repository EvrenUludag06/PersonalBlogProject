using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.EducationDtos
{
    public class EducationListDto : DtoGetBase
    {
        public IList<Education> Educations { get; set; }
    }
}
