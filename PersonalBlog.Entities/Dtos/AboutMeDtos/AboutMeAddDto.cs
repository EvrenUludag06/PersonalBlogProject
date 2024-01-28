using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.AboutMeDtos
{
	public class AboutMeAddDto
	{
		[DisplayName("Ad")]
		[Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
		[MaxLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
		[MinLength(5, ErrorMessage = "{0} en az {1} karakter olmalıdır!")]
		public string FisrtName { get; set; }
		//
		[DisplayName("Soyad")]
		[Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
		[MaxLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
		[MinLength(5, ErrorMessage = "{0} en az {1} karakter olmalıdır!")]
		public string LastName { get; set; }
		//
		[DisplayName("Profil Fotoğrafı")]
		[Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
		[MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
		public string ImagePath { get; set; }
		//
		[DisplayName("Meslek")]
		[Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
		[MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
		[MinLength(1, ErrorMessage = "{0} en az {1} karakter olmalıdır!")]
		public string MyJob { get; set; }
		//
		[DisplayName("Meslek İkonu")]
		[Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
		[MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
		[MinLength(5, ErrorMessage = "{0} en az {1} karakter olmalıdır!")]
		public string MyJobFA { get; set;}
		//
		[DisplayName("Özgeçmiş Dosyası")]
		[Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
		[MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
		[MinLength(5, ErrorMessage = "{0} en az {1} karakter olmalıdır!")]
		public string MyCvPath { get; set; }
		//
		[DisplayName("Doğum Tarihi")]
		[Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
		public DateTime BirthDate { get; set; }
    }
}
