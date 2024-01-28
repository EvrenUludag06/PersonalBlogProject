using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.InterestedsDtos;
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
    public class InterestedController : Controller
    {
        private readonly IInterestedsService _interestedService;

        public InterestedController(IInterestedsService interestedService)
        {
            _interestedService = interestedService;
        }
        public async Task<IActionResult> Index()
        {
            var interesteds = await _interestedService.GetAll();
            if (interesteds.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (interesteds.ResultStatus == ResultStatus.Success)
            {
                return View(interesteds.Data);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(InterestedsAddDto interestedAddDto)
        {
            if (ModelState.IsValid)
            {
                await _interestedService.Add(interestedAddDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View(interestedAddDto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var interested = await _interestedService.GetUpdateDto(id);
            if (interested.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (interested.ResultStatus == ResultStatus.Success)
            {
                return View(interested.Data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InterestedsUpdateDto interestedUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _interestedService.Update(interestedUpdateDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View(interestedUpdateDto);
        }
        public async Task<IActionResult> HardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var interested = await _interestedService.Get(id);
            if (interested.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (interested.ResultStatus == ResultStatus.Success)
            {
                return View(interested.Data);
            }
            return NotFound();
        }
        public async Task<IActionResult> DoHardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            await _interestedService.HardDelete(id);
            return RedirectToAction("Index");
        }
    }
}