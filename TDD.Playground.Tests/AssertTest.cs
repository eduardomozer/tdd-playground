using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Playground.PersonClasses;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class AssertTest
    {
        #region Are Equal/Are Not Equal Tests

        [TestMethod]
        [Owner("Eduardo")]
        public void AreEqual_Test()
        {
            var str1 = "John";
            var str2 = "John";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Eduardo")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitive_Test()
        {
            var str1 = "John";
            var str2 = "john";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void AreNotEqual_Test()
        {
            string str1 = "John";
            string str2 = "Jack";

            Assert.AreNotEqual(str1, str2);
        }

        #endregion

        #region Are Same/Are Not Same Tests

        [TestMethod]
        [Owner("Eduardo")]
        public void AreSame_Test()
        {
            var x = new FileProcess();
            var y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void AreNotSame_Test()
        {
            var x = new FileProcess();
            var y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion

        #region IsInstanceOfType/IsNull Test

        [TestMethod]
        [Owner("Eduardo")]
        public void IsInstanceOfType_Test()
        {
            var personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("John", "Doe", true);

            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void IsNull_Test()
        {
            var personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("", "Doe", true);

            Assert.IsNull(person);
        }

        #endregion
    }
}