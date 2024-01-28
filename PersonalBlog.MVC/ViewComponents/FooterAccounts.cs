using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SocialMediaAccountDtos;
using PersonalBlog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class FooterAccounts : ViewComponent
    {
        private readonly ISocialMediaAccountService _socialMediaAccountService;

        public FooterAccounts(ISocialMediaAccountService socialMediaAccountService)
        {
            _socialMediaAccountService = socialMediaAccountService;
        }
        public IViewComponentResult Invoke()
        {
            var list = GetAccounts().Result;
            return View(list);
        }
        public async Task<AccountsListDto> GetAccounts()
        {
            var accounts = await _socialMediaAccountService.GetAllByNonDeleteAndActive();
            return accounts.Data;
        }
    }
}
