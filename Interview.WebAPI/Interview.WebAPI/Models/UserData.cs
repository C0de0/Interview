using Interview.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.WebAPI.Models
{
    public class UserData
    {
        public string Login { get; set; }

        public User ToUser()
        {
            throw new NotImplementedException();
        }
    }
}
