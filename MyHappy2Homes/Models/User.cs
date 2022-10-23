using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace MyHappy2Homes.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int Age;

    }
}
