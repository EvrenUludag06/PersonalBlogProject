using PersonalBlog.Data.Abstract;
using PersonalBlog.Data.Concrete.EntityFramework.Contexts;
using PersonalBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly PersonalBlogContext _context;
		private EfAboutMeRepository _efAboutMeRepository;
		private EfAdminRepository _efAdminRepository;
		private EfArticleRepository _efArticleRepository;
		private EfCategoriesRepository _efCategoryRepository;
		private EfCommentRepository _efCommentRepository;
		private EfContactInfoRepository _efContactInfoRepository;
		private EfEducationRepository _efEducationRepository;
		private EfExperiencesRepository _efExperienceRepository;
		private EfHomePageSlidersRepository _efHomePageSliderRepository;
		private EfInterestedsRepository _efInterestedRepository;
		private EfMessagesRepository _efMessageRepository;
		private EfSiteIdentityRepository _efSiteIdentityRepository;
		private EfSkillsRepository _efSkillRepository;
		private EfSocialMediaAccountsRepository _efSocialMediaAccountRepository;
		private EfSummaryRepository _efSummaryRepository;

		public UnitOfWork(PersonalBlogContext context)
		{
			_context = context;
		}

		public IAboutMeRepository AboutMe => _efAboutMeRepository ?? new EfAboutMeRepository(_context);

		public IAdminRepository Admin => _efAdminRepository ?? new EfAdminRepository(_context);

		public IArticleRepository Article => _efArticleRepository ?? new EfArticleRepository(_context);

		public ICategoriesRepository Category => _efCategoryRepository ?? new EfCategoriesRepository(_context);

		public ICommentRepository Comment => _efCommentRepository ?? new EfCommentRepository(_context);

		public IContactInfoRepository ContactInfo => _efContactInfoRepository ?? new EfContactInfoRepository(_context);

		public IEducationRepository Education => _efEducationRepository ?? new EfEducationRepository(_context);
		public IExperiencesRepository Experience => _efExperienceRepository ?? new EfExperiencesRepository(_context);
		public IHomePageSlidersRepository HomePageSlider => _efHomePageSliderRepository ?? new EfHomePageSlidersRepository(_context);
		public IInterestedsRepository Interested => _efInterestedRepository ?? new EfInterestedsRepository(_context);
		public IMessagesRepository Message => _efMessageRepository ?? new EfMessagesRepository(_context);

		public ISiteIdentityRepository SiteIdentity => _efSiteIdentityRepository ?? new EfSiteIdentityRepository(_context);

		public ISkillRepository Skill => _efSkillRepository ?? new EfSkillsRepository(_context);
		public ISocialMediaAccountsRepository SocialMediaAccount => _efSocialMediaAccountRepository ?? new EfSocialMediaAccountsRepository(_context);

		public ISummaryRepository Summary => _efSummaryRepository ?? new EfSummaryRepository(_context);

        public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
