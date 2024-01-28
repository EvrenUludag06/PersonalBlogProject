using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Skills : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public int PercentageValue { get; set; }
    }
}
