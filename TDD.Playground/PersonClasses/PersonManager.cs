using System.Collections.Generic;

namespace TDD.Playground.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string firstName, string lastName, bool isSupervisor)
        {
            Person person = null;

            if (!string.IsNullOrEmpty(firstName))
            {
                if (isSupervisor)
                {
                    person = new Supervisor(firstName, lastName);
                }
                else
                {
                    person = new Employee(firstName, lastName);
                }
            }

            return person;
        }

        public List<Person> GetPeople()
        {
            var people = new List<Person>
            {
                new Person("Jack", "Sparrow"),
                new Person("Marlon", "Brando"),
                new Person("James", "Bond")
            };

            return people;
        }

        public List<Person> GetSupervisors()
        {
            var people = new List<Person>();

            people.Add(CreatePerson("Jack", "Sparrow", true));
            people.Add(CreatePerson("Marlon", "Brando", true));

            return people;
        }
    }
}