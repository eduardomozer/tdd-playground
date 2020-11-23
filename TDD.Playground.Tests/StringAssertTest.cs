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
            var str1 = "Executando Teste Com Contains";
            var str2 = "Contains";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void StartsWith_Test()
        {
            var str1 = "Executando Teste Com StartsWith";
            var str2 = "Executando Teste";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void IsAllLowerCase_Test()
        {
            var regex = new Regex(@"^([^A-Z])+$");
            StringAssert.Matches("executando teste", regex);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void IsNotAllLowerCase_Test()
        {
            var regex = new Regex(@"^([^A-Z])+$");
            StringAssert.DoesNotMatch("Executando teste", regex);
        }
    }
}