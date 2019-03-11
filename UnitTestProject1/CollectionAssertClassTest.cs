using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTest.Models;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("Rolando")]
        public void AreCollectionsEqualFailsBecauseNoComparerTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Rolando", LastName = "Naranjo" });
            peopleExpected.Add(new Person() { FirstName = "Krizhia", LastName = "Naranjo" });
            peopleExpected.Add(new Person() { FirstName = "Khleo", LastName = "Naranjo" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Rolando")]
        public void AreCollectionsEqualWithComparerTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Rolando", LastName = "Naranjo" });
            peopleExpected.Add(new Person() { FirstName = "Krizhia", LastName = "Naranjo" });
            peopleExpected.Add(new Person() { FirstName = "Khleo", LastName = "Naranjo" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual,Comparer<Person>
                .Create((x,y)=> x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }
        [TestMethod]
        [Owner("Rolando")]
        public void AreCollectionsEqualTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetPeople();
            peopleExpected = peopleActual;

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Rolando")]
        public void AreEquivalentTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);


            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }
        [TestMethod]
        [Owner("Rolando")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }

    }
}
