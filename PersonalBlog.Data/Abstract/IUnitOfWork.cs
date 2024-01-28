using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Abstract
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IAboutMeRepository AboutMe { get; }
		IAdminRepository Admin { get; }
		IArticleRepository Article { get; }
		ICategoriesRepository Category { get; }
		ICommentRepository Comment { get; }
		IContactInfoRepository ContactInfo { get; }
		IEducationRepository Education { get; }
		IExperiencesRepository Experience { get; }
		IHomePageSlidersRepository HomePageSlider { get; }
		IInterestedsRepository Interested { get; }
		IMessagesRepository Message { get; }
		ISiteIdentityRepository SiteIdentity { get; }
		ISkillRepository Skill { get; }
		ISocialMediaAccountsRepository SocialMediaAccount { get; }
		ISummaryRepository Summary { get; }
		Task<int> SaveAsync();
	}
}
