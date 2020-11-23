using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TDD.Playground.PersonClasses;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class CollectionAssertTest
    {
        [TestMethod]
        [Owner("Eduardo")]
        public void AreCollectionEqualFailsBecauseNoComparer_Test()
        {
            var peopleExpected = new List<Person>
            {
                new Person("Jack", "Sparrow"),
                new Person("Marlon", "Brando"),
                new Person("James", "Bond")
            };

            var personManager = new PersonManager();
            var peopleActual = personManager.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void AreCollectionEqualWithComparer_Test()
        {
            var personManager = new PersonManager();
            var peopleActual = new List<Person>();
            var peopleExpected = new List<Person>
            {
                new Person("Jack", "Sparrow"),
                new Person("Marlon", "Brando"),
                new Person("James", "Bond")
            };

            peopleActual = personManager.GetPeople();

            var comparer = Comparer<Person>.Create((p1, p2) => (p1.FirstName == p2.FirstName && p1.LastName == p2.LastName) ? 0 : 1);

            CollectionAssert.AreEqual(peopleExpected, peopleActual, comparer);
        }

        [TestMethod]
        [Owner("Eduardo")]
        public void AreCollectionEquivalent_Test()
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
        [Owner("Eduardo")]
        public void IsCollectionOfType_Test()
        {
            var personManager = new PersonManager();
            var peopleActual = new List<Person>();

            peopleActual = personManager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
    }
}