using System;

namespace WebBackEnd.Domains.User.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public long VKID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ScreenName { get; set; }
    }
}
