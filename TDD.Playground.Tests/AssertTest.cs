using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Playground.PersonClasses;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class AssertTest
    {
        #region Are Equal/Are Not Equal Tests

        [TestMethod]
        [Owner("EduardoCM")]
        public void AreEqualTest()
        {
            var str1 = "John";
            var str2 = "John";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            var str1 = "John";
            var str2 = "john";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void AreNotEqualTest()
        {
            string str1 = "Eduardo";
            string str2 = "Roger";

            Assert.AreNotEqual(str1, str2);
        }

        #endregion

        #region Are Same/Are Not Same Tests

        [TestMethod]
        public void AreSameTest()
        {
            var x = new FileProcess();
            var y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            var x = new FileProcess();
            var y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion

        #region IsInstanceOfType/IsNull Test

        [TestMethod]
        [Owner("EduardoCM")]
        public void IsInstanceOfTypeTest()
        {
            var personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("Eduardo", "Mozer", true);

            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void IsNullTest()
        {
            var personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("", "Mozer", true);

            Assert.IsNull(person);
        }

        #endregion
    }
}