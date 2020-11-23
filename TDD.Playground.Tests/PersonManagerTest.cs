using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Playground.PersonClasses;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("Eduardo")]
        public void CreatePersonOfTypeEmployee_Test()
        {
            var personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("John", "Doe", false);

            Assert.IsInstanceOfType(person, typeof(Employee));
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void DoEmployeeExist_Test()
        {
            var supervisor = new Supervisor("John", "Doe");

            supervisor.Employees.Add(new Employee("Jack", "Sparrow"));

            Assert.IsTrue(supervisor.Employees.Count > 0);
        }
    }
}