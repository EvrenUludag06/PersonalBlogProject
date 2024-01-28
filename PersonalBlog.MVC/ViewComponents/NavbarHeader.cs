using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SiteIdentityDtos;
using PersonalBlog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class NavbarHeader : ViewComponent
    {
        private readonly ISiteIdentityService _siteIdentityService;

        public NavbarHeader(ISiteIdentityService siteIdentityService)
        {
            _siteIdentityService = siteIdentityService;
        }
        public IViewComponentResult Invoke()
        {
            var idnt = GetIdentity().Result;
            return View(idnt);
        }
        public async Task<SiteIdentityDto> GetIdentity()
        {
            var identity = await _siteIdentityService.Get(1);
            return identity.Data;
        }
    }
}
