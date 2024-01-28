using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Data.Concrete.EntityFramework.Mappings
{
    public class SocialMediaAccountsMap : IEntityTypeConfiguration<SocialMediaAccounts>
    {
        public void Configure(EntityTypeBuilder<SocialMediaAccounts> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.AccountFA).IsRequired();
            builder.Property(x => x.AccountFA).HasMaxLength(150);
            builder.Property(x => x.AccountUrl).IsRequired();
            builder.Property(x => x.AccountUrl).HasMaxLength(250);
            builder.ToTable("SocialMediaAccounts");
            builder.HasData(new SocialMediaAccounts
            {
                Id = 1,
                Account="Instagram",
                AccountFA = "<i class=\"fab fa - Instagram - square\"></i>",
                AccountUrl = "https://www.instagram.com/evrenuludag_/",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            }, new SocialMediaAccounts
            {
                Id = 2,
                Account="X",
                AccountFA = "<i class=\"fab fa - twitter - square\"></i>",
                AccountUrl = "https://twitter.com/evrenuludag_",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            }, new SocialMediaAccounts
            {
                Id = 3,
                Account="Linkedin",
                AccountFA = "<i class=\"fab fa - linkedin\"></i>",
                AccountUrl = "https://www.linkedin.com/in/muhammet-evren-uluda%C4%9F-263537283/",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            }, new SocialMediaAccounts
            {
                Id = 4,
                Account="GitHub",
                AccountFA = "<i class=\"fab fa - github - square\"></i>",
                AccountUrl = "https://github.com/EvrenUludag06",
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
