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
    public class SummaryMap : IEntityTypeConfiguration<Summary>
    {
        public void Configure(EntityTypeBuilder<Summary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(75);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(75);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).HasColumnType("NVARCHAR(MAX)");
            builder.ToTable("Summary");
            builder.HasData(new Summary
            {
                Id = 1,
                CreatedByName = "IntialCreated",
                ModifiedByName = "IntialCreated",
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                IsActive = false,
                IsDelete = false,
                Content = "Merhaba siteme hoşgeldiniz. Ben Anadolu Üniversitesi'nin Web Tasarımı Ve Kodlama bölümünde okuyan aynı zamanda yazılıma gönül vermiş birisiyim. C# ve .Net alanında yoğun bir şekilde kendimi geliştiriyorum. Gelişime açık ve hızlı öğrenen birisi olduğumu düşünüyorum. Geleceğimi yazılım üzerine şekillendireceğime eminim. Bu yolda elimden geleni değil, herşeyi yapacağım. Yazılım üzerine birçok hayalim. uzun ve kısa vadeli planlarım var. Açıkcası yazılımın hayatımın her alanına yeterli ölçüde etki etmesini istiyorum. Bilgisayar, eskiden beri tutkum olan bir alan. Bilgisayardan birşeyler yazarak, bunun somut sonuçlarını görmek beni açıkcası mutlu ediyor..."
            });
            
        }
    }
}
