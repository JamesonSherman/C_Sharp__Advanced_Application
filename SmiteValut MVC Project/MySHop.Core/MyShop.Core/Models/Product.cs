using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyShop.Core.Models
{
    //inherits from BaseEntity.cs BaseEntity public class.
    public class Product : BaseEntity
    {
     
       

        //ourProduct Name with a String Length of 20 characters. using data annotations.
        [DisplayName("Product Name")]
        [StringLength(50)]
        public string Name { get; set; }
        //these other variables are set to build out the rest of the product
        public string Description { get; set; }
        //we give a realistic range on our products so we dont have rediculously large numbers for products.
        [Range(0,10000)]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

    }
}
