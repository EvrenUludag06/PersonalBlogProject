using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ContactInfoMap : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property(x => x.EMail).IsRequired();
            builder.Property(x => x.EMail).HasMaxLength(100);
            builder.Property(x => x.ShortAdress).IsRequired();
            builder.Property(x => x.ShortAdress).HasMaxLength(30);
            builder.Property(x => x.Adress).IsRequired();
            builder.Property(x => x.Adress).HasMaxLength(200);
            builder.ToTable("ContactInfo");
            builder.HasData(new ContactInfo
            {
                Id = 1,
                PhoneNumber = "+905059031910",
                EMail = "Evrenuludag563@gmail.com",
                ShortAdress = "BatıKent/Ankara",
                Adress = "Yeni Batı Mah. Mülk Cad. Göldelüx Konutları 1. Etap",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            });
        }
    }
}
