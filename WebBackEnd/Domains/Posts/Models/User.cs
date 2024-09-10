using System;

namespace WebBackEnd.Domains.Posts.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string VKID { get; set; }

    }
}
