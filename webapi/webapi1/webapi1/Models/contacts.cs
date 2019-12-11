using System;
using System.Activities.Debugger;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Models
{
    public class contacts
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public contacts()
        {
            ID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}