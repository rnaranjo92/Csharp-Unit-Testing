using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTest.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class AssertClassTest
    {
        [TestMethod]
        [Owner("Rolando")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Rolando","Naranjo",true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Rolando")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Naranjo", true);

            Assert.IsNull(per);
        }

        #region AreEqual/ArenotEqual Test
        [TestMethod]
        [Owner("Rolando")]
        public void AreEqualTest()
        {
            string str1 = "Rolando";
            string str2 = "Rolando";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Rolando")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Rolando";
            string str2 = "rolando";

            Assert.AreEqual(str1, str2, false);

        }

        [TestMethod]
        [Owner("Rolando")]
        public void AreNotEqualTest()
        {
            string str1 = "Rolando";
            string str2 = "Krizhia";

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Rolando")]
        public void AreSameTest()
        {
            FileProcessTest x = new FileProcessTest();
            FileProcessTest y = x;

            Assert.AreSame(x, y);
        }
        [TestMethod]
        [Owner("Rolando")]
        public void AreNotSameTest()
        {
            FileProcessTest x = new FileProcessTest();
            FileProcessTest y = new FileProcessTest();

            Assert.AreNotSame(x, y);
        }
        #endregion

    }
}
