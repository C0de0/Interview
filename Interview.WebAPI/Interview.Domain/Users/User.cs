using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Domain.Users
{
    public class User : IEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public Password Password { get; set; } 
    }

}
