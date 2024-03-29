﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SkillsDtos;
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
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        public async Task<IActionResult> Index()
        {
            var skills = await _skillService.GetAll();
            if (skills.ResultStatus == ResultStatus.Success)
            {
                return View(skills.Data);
            }
            if (skills.ResultStatus == ResultStatus.Error)
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
            var skill = await _skillService.Get(id);
            if (skill.ResultStatus == ResultStatus.Success)
            {
                return View(skill.Data);
            }
            if (skill.ResultStatus == ResultStatus.Error)
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
            var skill = await _skillService.GetUpdateDto(id);
            if (skill.ResultStatus == ResultStatus.Success)
            {
                return View(skill.Data);
            }
            if (skill.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillsUpdateDto skillUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _skillService.Update(skillUpdateDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var skill = await _skillService.Get(id);
            if (skill.ResultStatus == ResultStatus.Success)
            {
                return View(skill.Data);
            }
            if (skill.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }
        public async Task<IActionResult> DoHardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            await _skillService.HardDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(SkillsAddDto skillAddDto)
        {
            if (ModelState.IsValid)
            {
                await _skillService.Add(skillAddDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}