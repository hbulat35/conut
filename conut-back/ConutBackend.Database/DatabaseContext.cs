using ConutBackend.Database.Models;
using ConutBackend.Database.Models.Articles;
using ConutBackend.Database.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Article> Articles { get; set; }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<UserLink> UserLinks { get; set; }

        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}
