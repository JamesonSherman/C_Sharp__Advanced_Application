using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace polymorphism
{
    class M3:BMW{
     public M3(int peram_hp, string peram_color, string peram_model):base(peram_hp,peram_color, peram_model)
         {
           this.Model = peram_model;
         }

        //sealed can be placed so that further inherted methods can not be over ridden.
        //sealed allows no override
        //virtual allows for override
        //you can also seal classes
         public sealed override void Repair()
         {
             base.Repair();
         }
    }
}