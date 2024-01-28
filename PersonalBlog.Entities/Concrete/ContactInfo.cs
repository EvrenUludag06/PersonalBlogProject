using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class ContactInfo : BaseEntity, IEntity
    {
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string ShortAdress { get; set; }
        public string Adress { get; set; }
    }
}
