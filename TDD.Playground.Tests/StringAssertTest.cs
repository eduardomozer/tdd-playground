using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class StringAssertTest
    {
        [TestMethod]
        [Owner("EduardoCM")]
        public void ContainsTest()
        {
            var str1 = "Executando Teste Com Contains";
            var str2 = "Contains";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void StartsWithTest()
        {
            var str1 = "Executando Teste Com StartsWith";
            var str2 = "Executando Teste";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void IsAllLowerCaseTest()
        {
            var regex = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("executando teste", regex);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void IsNotAllLowerCaseTest()
        {
            var regex = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Executando teste", regex);
        }
    }
}