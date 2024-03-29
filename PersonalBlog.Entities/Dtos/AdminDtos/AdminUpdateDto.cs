﻿using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalBlog.Entities.Dtos.AdminDtos
{
    public class AdminUpdateDto
    {
        [Required]
        public int Id { get; set; }
        //
        [DisplayName("E-Mail")]
        [Required(ErrorMessage ="{0} alanı boş geçilmemelidir!")]
        [MaxLength(100,ErrorMessage ="{0} alanı en fazla {1} karakter olmalıdır!")]
        [MinLength(10,ErrorMessage ="{0} alanı {1} karakterden az olmamalıdır!")]
        public string EMail { get; set; }
        //
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
        [MaxLength(200, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır!")]
        [MinLength(6, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır!")]
        public string Password { get; set; }
        //
        [DisplayName("Güvenlik Sorusu")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
        [MaxLength(100, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır!")]
        [MinLength(10, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır!")]
        public string SecurituQuestion { get; set; }
        //
        [DisplayName("Güvenlik Sorusu Cevap")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir!")]
        [MaxLength(200, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır!")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır!")]
        public string SQAnswer { get; set; }
        //
        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir!")]
        public bool IsActive { get; set; }
        //
        [DisplayName("Silindi mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir!")]
        public bool IsDelete { get; set; }
    }
}
