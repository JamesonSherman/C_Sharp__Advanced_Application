using System;
using System.Collections.Generic;
using System.Text;

namespace XUNITExample_1
{
    public class Names
    {
        public string NickName { get; set; }
        public string MakeFullNname(string First, string Last)
        {
            return $"{First} {Last}";
        }
    }
}
