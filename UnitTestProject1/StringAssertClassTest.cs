using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("Rolando")]
        public void ContainTest()
        {
            string str1 = "John Wick";
            string str2 = "Wick";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Rolando")]
        public void StartsWithTest()
        {
            string str1 = "Putang ina mo";
            string str2 = "Putang ina";

            StringAssert.StartsWith(str1, str2);
        }
        [TestMethod]
        [Owner("Rolando")]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        [Owner("Rolando")]
        public void IsNotAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All lower case", r);
        }
    }
}
