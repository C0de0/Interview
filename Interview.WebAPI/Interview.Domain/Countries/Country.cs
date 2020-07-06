using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Domain.Countries
{
    public class Country : IValueObject
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
