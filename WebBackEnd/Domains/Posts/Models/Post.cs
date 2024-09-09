using System;

namespace WebBackEnd.Domains.Posts.Models
{
    public class Post 
    {
        public Guid Id { get; set; }

        public string Link { get; set; }

        public string Content { get; set; }
    }
}
