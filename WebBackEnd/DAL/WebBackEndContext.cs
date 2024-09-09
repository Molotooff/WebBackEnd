using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebBackEnd.Domains.Posts.Models;

namespace WebBackEnd.DAL
{
    public class WebBackEndContext : DbContext
    {
        public DbSet<Post> posts { get; set; }
        public string Content { get; internal set; }
        public string Link { get; internal set; }
        public Guid Id { get; internal set; }

        public WebBackEndContext(DbContextOptions<WebBackEndContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
