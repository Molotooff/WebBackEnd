using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebBackEnd.Domains.Posts.Models;
using WebBackEnd.Domains.User.Models;

namespace WebBackEnd.DAL
{
    public class WebBackEndContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> User { get; set; }

        public WebBackEndContext(DbContextOptions<WebBackEndContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
