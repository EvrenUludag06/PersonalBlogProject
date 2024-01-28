using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Concrete.EntityFramework.Mappings;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete.EntityFramework.Contexts
{
    public class PersonalBlogContext : DbContext
    {
        public DbSet<Summary> Summary { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Interesteds> Interesteds { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<SocialMediaAccounts> SocialMediaAccounts { get; set; }
        public DbSet<HomePageSliders> HomePageSliders { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Experiences> Experiences { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<SiteIdentity> SiteIdentity { get; set; }
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server = LAPTOP-AKHM4D45; Database = PersonalBlogDB; Trusted_Connection = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SummaryMap());
            modelBuilder.ApplyConfiguration(new InterestedsMap());
            modelBuilder.ApplyConfiguration(new SocialMediaAccountsMap());
            modelBuilder.ApplyConfiguration(new HomePageSlidersMap());
            modelBuilder.ApplyConfiguration(new SkillsMap());
            modelBuilder.ApplyConfiguration(new ExperiencesMap());
            modelBuilder.ApplyConfiguration(new SiteIdentityMap());
            modelBuilder.ApplyConfiguration(new MessagesMap());
            modelBuilder.ApplyConfiguration(new AboutMeMap());
            modelBuilder.ApplyConfiguration(new AdminMap());
            modelBuilder.ApplyConfiguration(new EducationsMap());
            modelBuilder.ApplyConfiguration(new ArticlesMap());
            modelBuilder.ApplyConfiguration(new ContactInfoMap());
            modelBuilder.ApplyConfiguration(new CommentsMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
        }
    }
}