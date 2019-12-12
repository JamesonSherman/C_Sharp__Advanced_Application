using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUNITExample_1;

namespace Calculation.Tests
{
    [Collection("Customer")]
    public class CustomerTests
    {

        private readonly CustomerFixture _customerFixture;

        public CustomerTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        //checks if the name is not null or empty
        [Fact]
        public void checkNameNotEmpty()
        {
            var customer = _customerFixture.Cust;
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        //checks bound of values via inRange
        [Fact]
        public void CheckLegitForDiscount()
        {
            var customer = _customerFixture.Cust;
            Assert.InRange(customer.Age, 25, 40);
        }

        //checks the exception from getordersbyname of class customer.
        [Fact]
        public void GetOrdersByNameNotNull()
        {
            var customer = _customerFixture.Cust;
            var exceptiondetails = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            Assert.Equal("Hello", exceptiondetails.Message);
        }

        //build factory pattern check that uses a redundent typeof check to make sure the static class of customer factory returns
        //a loyalcustomer over a normal customer. the stipulation on this is that the passed value to the peram must be <= 100.
        [Fact]
        public void LoyalACustomerForOrdersG100()
        {
            var factorymadecustomer = CustomerFactory.CreatCustomerInstance(101);
#pragma warning disable xUnit2007 // Do not use typeof expression to check the type
            Assert.IsType(typeof(LoyalCustomer), factorymadecustomer);
#pragma warning restore xUnit2007 // Do not use typeof expression to check the type
        }

        //better version of the previous test. also checks for equality of loyalcustomer.discount.
        [Fact]
        public void LoyalACustomerForOrdersG1002()
        {
            var factorymadecustomer = CustomerFactory.CreatCustomerInstance(101);
            var loyalCustomer = Assert.IsType<LoyalCustomer>(factorymadecustomer);
            Assert.Equal(10, loyalCustomer.Discount);
        }


    }
}
