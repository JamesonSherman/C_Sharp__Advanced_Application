using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUNITExample_1;

namespace Calculation.Tests
{
    //creates a collection annotation for a generic collection of test types.
    [Collection("Customer")]
    public class CustomerDetailsTest
    {
        //allows us to share a customer fixture. as a dependency injection.
        private readonly CustomerFixture _customerFixture;

        public CustomerDetailsTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstandLastName_ReturnsFullName()
        {
            var customer = _customerFixture.Cust;
            Assert.Equal("John Smith", customer.GetFullName("John", "Smith"));
        }
    }
}
