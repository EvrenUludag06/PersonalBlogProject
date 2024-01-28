using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.ContactInfoDtos
{
    public class ContactInfoDto : DtoGetBase
    {
        public ContactInfo ContactInfo { get; set; }
    }
}
