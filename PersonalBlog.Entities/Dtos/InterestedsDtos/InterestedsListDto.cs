using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.InterestedsDtos
{
    public class InterestedsListDto : DtoGetBase
    {
        public IList<Interesteds> Interesteds { get; set; }
    }
}
