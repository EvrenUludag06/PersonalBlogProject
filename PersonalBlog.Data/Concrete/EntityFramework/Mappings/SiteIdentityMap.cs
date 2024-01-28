using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApp.Data.Concrete.EntityFramework.Mappings
{
    public class SiteIdentityMap : IEntityTypeConfiguration<SiteIdentity>
    {
        public void Configure(EntityTypeBuilder<SiteIdentity> builder)
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
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Keywords).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.Property(x => x.LogoFA).IsRequired();
            builder.Property(x => x.LogoFA).HasMaxLength(150);
            builder.Property(x => x.LogoText).IsRequired();
            builder.Property(x => x.LogoText).HasMaxLength(60);
            builder.ToTable("SiteIdentity");
            builder.HasData(new SiteIdentity
            {
                Id = 1,
                Title = "Muhammet Evren Uludağ",
                Keywords = "Muhammet Evren Uludağ, Muhammet, Evren, Uludağ, Software, Developer, Engineer",
                Description = "Ben Muhammet Evren Uludağ. Yazılım geliştiricisiyim. C# ve web bilgim var.",
                LogoFA = "<i class=\"fab fa - hire - a - helper\"></i>",
                LogoText = "EVREN ULUDAG",
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
