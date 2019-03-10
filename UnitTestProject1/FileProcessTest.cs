using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass.Models;
using System;
using System.Configuration;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.bad";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();
            TestContext.WriteLine("Creating the file:" + _GoodFileName);
            File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine("Testing the file:" + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            TestContext.WriteLine("Deleting the file:" + _GoodFileName);
            File.Delete(_GoodFileName);

            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
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
