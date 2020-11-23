using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Playground.PersonClasses;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("EduardoCM")]
        public void CreatePerson_OfType_Employee_Test()
        {
            var personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("John", "Doe", false);

            Assert.IsInstanceOfType(person, typeof(Employee));
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void DoEmployeeExist_Test()
        {
            var supervisor = new Supervisor("John", "Doe");

            supervisor.Employees.Add(new Employee("Jack", "Sparrow"));

            Assert.IsTrue(supervisor.Employees.Count > 0);
        }
    }
}