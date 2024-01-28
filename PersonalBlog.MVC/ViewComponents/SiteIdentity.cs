using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SiteIdentityDtos;
using PersonalBlog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class SiteIdentity : ViewComponent
    {
        private readonly ISiteIdentityService _siteIdentityService;

        public SiteIdentity(ISiteIdentityService siteIdentityService)
        {
            _siteIdentityService = siteIdentityService;
        }
        public IViewComponentResult Invoke(string title)
        {
            var data = GetSiteIdentity(title).Result;
            return View(data);
        }
        public async Task<SiteIdentityDto> GetSiteIdentity(string add)
        {
            var identity = await _siteIdentityService.Get(1);
            identity.Data.SiteIdentity.Title = identity.Data.SiteIdentity.Title + " | " + add;
            return identity.Data;
        }
    }
}
