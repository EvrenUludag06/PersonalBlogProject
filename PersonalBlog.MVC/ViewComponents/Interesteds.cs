using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.InterestedsDtos;
using PersonalBlog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class Interesteds : ViewComponent
    {
        private readonly IInterestedsService _interestedService;

        public Interesteds(IInterestedsService interestedService)
        {
            _interestedService = interestedService;
        }
        public IViewComponentResult Invoke()
        {
            var datas = GetInteresteds().Result;
            return View(datas);
        }
        public async Task<InterestedsListDto> GetInteresteds()
        {
            var interesteds = await _interestedService.GetAllByNonDeleteAndActive();
            return interesteds.Data;
        }
    }
}
