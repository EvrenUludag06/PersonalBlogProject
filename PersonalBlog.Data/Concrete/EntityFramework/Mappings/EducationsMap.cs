using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Data.Concrete.EntityFramework.Mappings
{
    public class EducationsMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.School).IsRequired();
            builder.Property(x => x.School).HasMaxLength(120);
            builder.Property(x => x.Duraiton).IsRequired();
            builder.Property(x => x.Duraiton).HasMaxLength(50);
            builder.Property(x => x.Avarage).IsRequired();
            builder.Property(x => x.Avarage).HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.ToTable("Educations");
            builder.HasData(new Education
            {
                Id = 1,
                Title = "Lisans Derecesi",
                School = "Anadolu Üniversitesi Web Tasarımı Ve Kodlama Bölümü",
                Duraiton = "Eylül 2023--Yeni Başladı",
                Avarage = "...",
                Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Exercitationem recusandae quibusdam expedita, vitae veniam aut",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            }, new Education
            {
                Id = 2,
                Title = "Lise Mezun",
                School = "Nasrettin Hoca Mesleki Ve Teknik Anadolu Lisesi",
                Duraiton = "Eylül 2016--Temmuz 2021",
                Avarage = "81.63 ORT",
                Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Exercitationem recusandae quibusdam expedita, vitae veniam aut",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            }
            );
        }
    }
}
