﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.ExperiencesDtos;
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
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async  Task<IActionResult> Index()
        {
            var experiences = await _experienceService.GetAll();
            if (experiences.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (experiences.ResultStatus == ResultStatus.Success)
            {
                return View(experiences.Data);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExperiencesAddDto experienceAddDto)
        {
            if (ModelState.IsValid)
            {
                await _experienceService.Add(experienceAddDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View(experienceAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var experience = await _experienceService.GetUpdateDto(id);
            if (experience.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (experience.ResultStatus == ResultStatus.Success)
            {
                return View(experience.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExperiencesUpdateDto experienceUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _experienceService.Update(experienceUpdateDto, "Evren Uludağ");
                return RedirectToAction("Index");
            }
            return View(experienceUpdateDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var experience = await _experienceService.Get(id);
            if (experience.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (experience.ResultStatus == ResultStatus.Success)
            {
                return View(experience.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var experience = await _experienceService.Get(id);
            if (experience.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (experience.ResultStatus == ResultStatus.Success)
            {
                return View(experience.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            await _experienceService.HardDelete(id);
            return RedirectToAction("Index");
        }
    }
}
