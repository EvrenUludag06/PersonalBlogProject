using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Experiences : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string WorkPlace { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
