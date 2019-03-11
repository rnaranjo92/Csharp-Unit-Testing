using System.Collections.Generic;

namespace MyTest.Models
{
    public class Supervisor: Person
    {
        public List<Employee> Employees { get; set; }
    }
}