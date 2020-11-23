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
                new Person("Eduardo", "Mozer"),
                new Person("Donald", "Trump"),
                new Person("Joe", "Biden")
            };

            return people;
        }

        public List<Person> GetSupervisors()
        {
            var people = new List<Person>();

            people.Add(CreatePerson("Eduardo", "Mozer", true));
            people.Add(CreatePerson("Donald", "Trump", true));

            return people;
        }
    }
}