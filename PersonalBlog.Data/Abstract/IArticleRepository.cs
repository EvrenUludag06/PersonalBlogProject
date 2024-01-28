using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Abstract
{
	public interface IArticleRepository : IEntityRepository<Articles>
	{
		Task<IList<Articles>> GetAllOrderByDescIdAsync(Func<object, bool> value1, Func<object, object> value2, Func<object, object> value3);
	}
}
