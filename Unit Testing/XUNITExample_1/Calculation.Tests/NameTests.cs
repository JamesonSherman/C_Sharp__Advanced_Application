using System;
using System.Collections.Generic;
using System.Text;
using XUNITExample_1;
using Xunit;

namespace Calculation.Tests
{
    public class NameTests
    {


        //checks string equality
        [Fact]
        public void MakeFullNameTest()
        {
            var name = new Names();
            var result = name.MakeFullNname("John", "Smith");
            Assert.Equal("John Smith", result);
        }

        //ignores case sensitivity
        [Fact]
        public void NonSensativeFullNameTest()
        {
            var name = new Names();
            var result = name.MakeFullNname("john", "Smith");
            Assert.Equal("John Smith", result, ignoreCase: true);
        }

        //contains method on assert
        [Fact]
        public void containsFullNameTest()
        {
            var name = new Names();
            var result = name.MakeFullNname("John", "Smith");
            Assert.Contains("John", result);
        }
        //double assert check with startswith and endswith
        [Fact]
        public void Startswith_Endswith_FullNameTest()
        {
            var name = new Names();
            var result = name.MakeFullNname("John", "Smith");
            Assert.StartsWith("John", result);
            Assert.EndsWith("Smith", result, StringComparison.InvariantCultureIgnoreCase);
        }
        //regex test
        [Fact]
        public void regexFullNameTest()
        {
            var name = new Names();
            var result = name.MakeFullNname("John", "Smith");
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }
        //must be null
        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();
            Assert.Null(names.NickName);
        }
        //must be null
        [Fact]
        public void NickNameNotNull()
        {
            var names = new Names();
            names.NickName = "boogie";
            Assert.NotNull(names.NickName);
        }
        //makes sure it returns anything
        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullNname("John", "Smith");
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
