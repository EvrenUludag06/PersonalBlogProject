using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.MessageDtos
{
    public class MessageListDto : DtoGetBase
    {
        public IList<Messages> Messages { get; set; }
    }
}
