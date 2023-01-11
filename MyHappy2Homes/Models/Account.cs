using System;
using System.Collections.Generic;
using System.Text;

namespace MyHappy2Homes.Models
{
    public class Account : User
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
