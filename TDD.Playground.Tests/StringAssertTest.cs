using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class StringAssertTest
    {
        [TestMethod]
        [Owner("Eduardo")]
        public void Contains_Test()
        {
            var str1 = "Running Test With Contains";
            var str2 = "Contains";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void StartsWith_Test()
        {
            var str1 = "Running Test With StartsWith";
            var str2 = "Running Test";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void IsAllLowerCase_Test()
        {
            var regex = new Regex(@"^([^A-Z])+$");
            StringAssert.Matches("running test", regex);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void IsNotAllLowerCase_Test()
        {
            var regex = new Regex(@"^([^A-Z])+$");
            StringAssert.DoesNotMatch("Running test", regex);
        }
    }
}