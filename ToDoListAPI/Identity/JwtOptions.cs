using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListAPI.Identity
{
    public class JwtOptions
    {
        public string JwtKey { get; set; }

        public string JwtIssuer { get; set; }

        public int JwtExpiryDays { get; set; }

    }
}
