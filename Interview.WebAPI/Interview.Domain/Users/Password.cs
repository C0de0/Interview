using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Domain.Users
{
    public class Password : IValueObject
    {
        public object EncryptedPass { get; set; } 
        
    }
}
