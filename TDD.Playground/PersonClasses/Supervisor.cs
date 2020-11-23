using System.Collections.Generic;

namespace TDD.Playground.PersonClasses
{
    public class Supervisor : Person
    {
        public Supervisor(string firstName, string lastName)
            : base(firstName, lastName)
        {
            Employees = new List<Employee>();
        }

        public List<Employee> Employees { get; set; }
    }
}