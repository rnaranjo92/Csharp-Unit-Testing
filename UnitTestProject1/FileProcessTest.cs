using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass.Models;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.bad";
        private string _GoodFileName;

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In the class initialize.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            
        }

        #region
        [TestInitialize]
        public void TestInitialize()
        {
            if(TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File:" + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting File:" + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion


        public TestContext TestContext { get; set; }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        public void FileNameDoesExistSimpleMessageSimulate()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File Does NOT exists.");
        }

        [TestMethod]
        public void FileNameDoesExistMessageWithFormattingSimulate()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File {0} Does NOT exists.", _GoodFileName);
        }

        [TestMethod]
        [Owner("Rolando")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
            TestContext.WriteLine("Checking file: " + fileName);

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }


        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [Timeout(3000)]
        [Ignore]
        public void SimulateIgnore()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [Description("Check if the file exist.")]
        [Owner("Rolando T Naranjo")]
        [Priority(0)]
        [TestCategory("FileNameDoesExit")]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            //TestContext.WriteLine("Creating the file:" + _GoodFileName);
            //File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine("Testing the file:" + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            //TestContext.WriteLine("Deleting the file:" + _GoodFileName);
            //File.Delete(_GoodFileName);

            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        [Owner("Krizhia Naranjo")]
        [Description("Check if the file does not exist.")]
        [Priority(0)]
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
        [Owner("Khleo Naranjo")]
        [Description("Check if the file is null or empty.")]
        [ExpectedException(typeof(ArgumentNullException))]
        [Priority(1)]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }
        [TestMethod]
        [Owner("Khleo Naranjo")]
        [Priority(1)]
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
