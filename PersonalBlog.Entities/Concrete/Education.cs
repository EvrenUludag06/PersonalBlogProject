using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Education : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string School { get; set; }
        public string Duraiton { get; set; }
        public string Avarage { get; set; }
        public string Description { get; set; }
    }
}
