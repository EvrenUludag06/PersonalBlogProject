using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.MessageDtos
{
    public class MessageDto : DtoGetBase
    {
        public Messages Messages { get; set; }
    }
}
