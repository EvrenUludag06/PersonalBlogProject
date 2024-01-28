using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Data.Concrete.EntityFramework.Mappings
{
    public class AdminMap : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.EMail).IsRequired();
            builder.Property(x => x.EMail).HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(200);
            builder.Property(x => x.SecurityQuestion).IsRequired();
            builder.Property(x => x.SecurityQuestion).HasMaxLength(100);
            builder.Property(x => x.SQAnswer).IsRequired();
            builder.Property(x => x.SQAnswer).HasMaxLength(200);
            builder.ToTable("Admin");
            builder.HasData(new Admin
            {
                Id = 1,
                EMail = "Evrenuludag563@gmail.com",
                Password = "80822c9ccfe0fb5bda1d9d9695071f0f",
                SecurityQuestion = "Anne kızlık soyadı (Küçük Harflerle)?",
                SQAnswer = "95292c82c277311cae9da7a64ac216f3",
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                IsActive = true,
                IsDelete = false
            });
        }
    }
}
