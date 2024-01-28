using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using PersonalBlog.Shared.Utilities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.AdminDtos
{
    public class AdminDto : DtoGetBase
    {
        public Admin Admin { get; set; }
    }
}
