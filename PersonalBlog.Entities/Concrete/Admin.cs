using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Admin : BaseEntity, IEntity
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SQAnswer { get; set; }
    }
}
