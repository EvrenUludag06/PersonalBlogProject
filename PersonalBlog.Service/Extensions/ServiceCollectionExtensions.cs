using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Data.Concrete;
using PersonalBlog.Data.Concrete.EntityFramework.Contexts;
using PersonalBlog.Service.Abstract;
using PersonalBlog.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PersonalBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IAboutMeService, AboutMeManager>();
            serviceCollection.AddScoped<IAdminService, AdminManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();
            serviceCollection.AddScoped<IContactInfoService, ContactInfoManager>();
            serviceCollection.AddScoped<IEducationService, EducationManager>();
            serviceCollection.AddScoped<IExperienceService, ExperienceManager>();
            serviceCollection.AddScoped<IHomePageSliderService, HomePageSliderManager>();
            serviceCollection.AddScoped<IInterestedsService, InterestedManager>();
            serviceCollection.AddScoped<IMessageService, MessageManager>();
            serviceCollection.AddScoped<ISiteIdentityService, SiteIdentityManager>();
            serviceCollection.AddScoped<ISkillService, SkillManager>();
            serviceCollection.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
            serviceCollection.AddScoped<ISummaryService, SummaryManager>();
            return serviceCollection;
        }
    }
}
