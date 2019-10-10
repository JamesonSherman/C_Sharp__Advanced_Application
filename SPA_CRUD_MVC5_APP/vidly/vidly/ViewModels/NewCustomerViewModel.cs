﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> ListedMembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}