using System.Collections.Generic;

namespace MyTest.Models
{
    public class PersonManager 
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }
                ret.FirstName = first;
                ret.LastName = last;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Rolando", LastName = "Naranjo" });
            people.Add(new Person() { FirstName = "Krizhia", LastName = "Naranjo" });
            people.Add(new Person() { FirstName = "Khleo", LastName = "Naranjo" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Rolando", "Naranjo", true));
            people.Add(CreatePerson("Krizhia", "Naranjo", true));

            return people;
        }
    }
}