using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class MembershipType
    {
        public byte DiscountRate { get; set; }
        public byte DurationInMonths { get; set; }
        public byte ID { get; set; }

        [Required]
        public String Name { get; set; }
        public short SignUpFee { get; set; }

        public static readonly byte Unknown = 0;

        public static readonly byte PayasYouGo = 1;
        
        


    }
}