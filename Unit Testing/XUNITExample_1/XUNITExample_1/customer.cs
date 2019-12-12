using System;
using System.Collections.Generic;
using System.Text;

namespace XUNITExample_1
{
    public class customer
    {
        public virtual int GetOrdersByName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Hello");
            }
            return 100;
        }
        public string Name => "John";
        public int Age => 35;

        public string GetFullName(string firstname, string lastName)
        {
            return $"{firstname} {lastName}";
        }

    }

    public class LoyalCustomer : customer
    {
        public int Discount { get; set; }

        public LoyalCustomer()
        {
            Discount = 10;
        }

        public override int GetOrdersByName(string name)
        {
            return 101;
        }
    }

    public static class CustomerFactory
    {
        public static customer CreatCustomerInstance(int orderCount)
        {
            if (orderCount <= 100)
                return new customer();
            else
                return new LoyalCustomer();
        }
    }


}
