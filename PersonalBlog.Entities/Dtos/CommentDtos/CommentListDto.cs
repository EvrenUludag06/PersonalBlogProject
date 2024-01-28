using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.CommentDtos
{
    public class CommentListDto : DtoGetBase
    {
        public IList<Comments> Comments { get; set; }
    }
}
