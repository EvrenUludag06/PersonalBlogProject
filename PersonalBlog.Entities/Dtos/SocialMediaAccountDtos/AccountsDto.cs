using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SocialMediaAccountDtos
{
    public class AccountsDto : DtoGetBase
    {
        public SocialMediaAccounts SocialMediaAccounts { get; set; }
    }
}
