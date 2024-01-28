using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.InterestedsDtos
{
    public class InterestedsDto : DtoGetBase
    {
        public Interesteds Interesteds { get; set; }
    }
}
