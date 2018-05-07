using System;

namespace Bubber.Models
{
    public class User
    {
        public Guid ID { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}