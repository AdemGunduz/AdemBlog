using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.concrete
{
    public class MyConnectionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string ConnetDeveloper = "server=localhost;port=3306;database=Blog;user=root;password=123456;Charset=utf8;";

            optionsBuilder.UseLazyLoadingProxies()
                .UseMySql(ConnetDeveloper, ServerVersion.AutoDetect(ConnetDeveloper))
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(warnings =>
                {
                    warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
                });

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        
    }
}   
