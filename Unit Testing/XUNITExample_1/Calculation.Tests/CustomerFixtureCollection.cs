using System;
using System.Collections.Generic;
using System.Text;
using XUNITExample_1;
using Xunit;

namespace Calculation.Tests
{
    [CollectionDefinition("Customer")]
    public class CustomerFixtureCollection: ICollectionFixture<CustomerFixture>
    {

    }
}
