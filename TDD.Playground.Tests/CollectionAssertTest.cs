using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TDD.Playground.PersonClasses;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class CollectionAssertTest
    {
        [TestMethod]
        [Owner("EduardoCM")]
        public void AreCollectionEqualFailsBecauseNoComparerTest()
        {
            var peopleExpected = new List<Person>
            {
                new Person("Eduardo", "Mozer"),
                new Person("Donald", "Trump"),
                new Person("Joe", "Biden")
            };

            // You sall not pass!
            var personManager = new PersonManager();
            var peopleActual = personManager.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void AreCollectionEqualWithComparerTest()
        {
            var personManager = new PersonManager();
            var peopleActual = new List<Person>();
            var peopleExpected = new List<Person>
            {
                new Person("Eduardo", "Mozer"),
                new Person("Donald", "Trump"),
                new Person("Joe", "Biden")
            };

            // You sall not pass!
            peopleActual = personManager.GetPeople();

            var comparer = Comparer<Person>.Create((p1, p2) => (p1.FirstName == p2.FirstName && p1.LastName == p2.LastName) ? 0 : 1);

            CollectionAssert.AreEqual(peopleExpected, peopleActual, comparer);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void AreCollectionEquivalentTest()
        {
            var personManager = new PersonManager();
            var peopleActual = new List<Person>();
            var peopleExpected = new List<Person>();

            peopleActual = personManager.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        public void IsCollectionOfTypeTest()
        {
            var personManager = new PersonManager();
            var peopleActual = new List<Person>();

            peopleActual = personManager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
    }
}