using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebBackEnd.Domains.Posts.Models;

namespace WebBackEnd.DAL
{
    public class WebBackEndContext : DbContext
    {
        public DbSet<Post> posts { get; set; }

        public DbSet<User> user { get; set; }

        public WebBackEndContext(DbContextOptions<WebBackEndContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
