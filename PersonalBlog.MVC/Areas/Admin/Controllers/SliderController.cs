using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SliderDtos;
using PersonalBlog.Service.Abstract;
using PersonalBlog.Shared.Utilities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly IHomePageSliderService _homePageSliderService;

        public SliderController(IHomePageSliderService homePageSliderService)
        {
            _homePageSliderService = homePageSliderService;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _homePageSliderService.GetAll();
            if (sliders.ResultStatus == ResultStatus.Success)
            {
                return View(sliders.Data);
            }
            if (sliders.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var slider = await _homePageSliderService.Get(id);
            if (slider.ResultStatus == ResultStatus.Success)
            {
                return View(slider.Data);
            }
            if (slider.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var slider = await _homePageSliderService.GetUpdateDto(id);
            if (slider.ResultStatus == ResultStatus.Success)
            {
                return View(slider.Data);
            }
            if (slider.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SlidersUpdateDto homePageSliderUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _homePageSliderService.Update(homePageSliderUpdateDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SlidersAddDto homePageSliderAddDto)
        {
            if (ModelState.IsValid)
            {
                await _homePageSliderService.Add(homePageSliderAddDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var slider = await _homePageSliderService.Get(id);
            if (slider.ResultStatus == ResultStatus.Success)
            {
                return View(slider.Data);
            }
            if (slider.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            await _homePageSliderService.HardDelete(id);
            return RedirectToAction("Index");
        }
    }
}
