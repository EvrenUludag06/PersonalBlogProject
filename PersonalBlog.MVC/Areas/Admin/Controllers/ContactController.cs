using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.ContactInfoDtos;
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
    public class ContactController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public async Task<IActionResult> Index()
        {
            var contact = await _contactInfoService.Get(1);
            if (contact.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (contact.ResultStatus == ResultStatus.Success)
            {
                return View(contact.Data);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var contact = await _contactInfoService.GetUpdateDto(id);
            if (contact.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (contact.ResultStatus == ResultStatus.Success)
            {
                return View(contact.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactInfoUpdateDto contactInfoUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _contactInfoService.Update(contactInfoUpdateDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View(contactInfoUpdateDto);
        }
    }
}