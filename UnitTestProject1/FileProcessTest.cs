using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass.Models;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\Regedit.exe");

            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\BadFileName.bad");

            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }
        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumentNullExceptionTryCatchException()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch(ArgumentNullException)
            {
                return;
            }
            Assert.Fail("Call to FileExists did not throw an argument null exception");
        }
    }
}
