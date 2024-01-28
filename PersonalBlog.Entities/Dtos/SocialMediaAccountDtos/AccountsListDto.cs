using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Entities.Dtos.SocialMediaAccountDtos
{
    public class AccountsListDto : DtoGetBase
    {
        public IList<SocialMediaAccounts> SocialMediaAccounts { get; set; }
    }
}
