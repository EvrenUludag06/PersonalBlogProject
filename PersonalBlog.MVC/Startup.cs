using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalBlog.Service.AutoMapper.Profiles;
using PersonalBlog.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PersonalBlog.MVC
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            object value = services.AddAutoMapper(typeof(AboutMeProfile), typeof(AdminProfile), typeof(ArticleProfile), typeof(CategoryProfile), typeof(CommentProfile), typeof(ContactInfoProfile), typeof(EducationProfile), typeof(ExperienceProfile), typeof(HomePageSliderProfile), typeof(InterestedProfile), typeof(MessageProfile), typeof(SiteIdentityProfile), typeof(SkillProfile), typeof(SocialMediaAccountProfile), typeof(SummaryProfile));
            services.LoadMyService();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => { opt.LoginPath = "/Admin/Session/LogIn"; });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                        name: "Admin",
                        areaName: "Admin",
                        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
