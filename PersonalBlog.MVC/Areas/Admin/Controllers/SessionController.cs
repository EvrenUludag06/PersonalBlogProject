using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.AdminDtos;
using PersonalBlog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionController : Controller
    {
        private readonly IAdminService _adminService;

        public SessionController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(AdminLoginDto adminLoginDto)
        {
            var adminInfo = await _adminService.Get(1);
            var admin = adminInfo.Data.Admin;
            using var md5 = MD5.Create();
            var result1 = md5.ComputeHash(Encoding.ASCII.GetBytes(adminLoginDto.Password));
            var strResult = BitConverter.ToString(result1);
            if (admin.EMail == adminLoginDto.EMail && admin.Password == strResult.Replace("-", ""))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, adminLoginDto.EMail)
                };
                var identity = new ClaimsIdentity(claims,"login");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home",new { area="Admin"});
            }
            return View(adminLoginDto);
        }
        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            var adminInfo = await _adminService.Get(1);
            ViewBag.SQ = adminInfo.Data.Admin.SecurityQuestion;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string sqAnswer)
        {
            return View(sqAnswer);
        }
    }
}