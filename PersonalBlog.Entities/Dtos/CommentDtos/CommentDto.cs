using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.CommentDtos
{
    public class CommentDto : DtoGetBase
    {
        public Comments Comments { get; set; }
    }
}
