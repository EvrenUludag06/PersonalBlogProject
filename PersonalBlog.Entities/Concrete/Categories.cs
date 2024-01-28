using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Categories : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string CategoryFA { get; set; }
        public string Description { get; set; }
        public ICollection<Articles> Articles { get; set; }
    }
}
