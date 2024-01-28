using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete.EntityFramework.Mappings
{
    public class InterestedsMap : IEntityTypeConfiguration<Interesteds>
    {
        public void Configure(EntityTypeBuilder<Interesteds> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();;
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(200);
            builder.ToTable("Interesteds");
            builder.HasData(new Interesteds
            {
                Id = 1,
                Text = "Bilgisayar Donanımları, Bileşenleri ve Yazılımları",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            }, new Interesteds
            {
                Id = 2,
                Text = "Vizyon Filmlerini takip etmek ve izlemek, Film incelemelerini okumak, Parodileri izlemek",
                IsActive = true,
                IsDelete = false,
                CreatedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedTime = DateTime.Now
            },
            new Interesteds
            {
                Id = 3,
                Text = "Animeler ve Mangalar",
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

