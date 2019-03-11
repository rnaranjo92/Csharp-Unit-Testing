using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    /// <summary>
    /// Assembly Initialize and Cleanup methods
    /// </summary>
    [TestClass]
    public class MyClassTestInitialization
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In the Assembly Initialize Method");
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

    }
}
