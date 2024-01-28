using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SiteIdentityDtos
{
    public class SiteIdentityDto : DtoGetBase
    {
        public SiteIdentity SiteIdentity { get; set; }
    }
}
