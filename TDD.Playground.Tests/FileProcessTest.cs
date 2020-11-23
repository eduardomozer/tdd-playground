using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace TDD.Playground.Tests
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\Regedit.exe";
        private const string FILE_NAME_TO_DEPLOY = @"FileToDeploy.txt";

        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith(nameof(FileNameDoesExists)))
            {
                SetGoodFileName();

                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating file: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith(nameof(FileNameDoesExists)))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting file: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        #region Test Methods

        [TestMethod]
        [Description("Check if a file does exist.")]
        [Owner("EduardoCM")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fileProcess.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesExistsSimpleMessage()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fileProcess.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File Does NOT Exists");
        }

        [TestMethod]
        public void FileNameDoesExistsMessageFormatting()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fileProcess.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File {0} Does NOT Exists", _GoodFileName);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        [DeploymentItem(FILE_NAME_TO_DEPLOY)]
        public void FileNameDoesExistsDeploymentItem()
        {
            var fileProcess = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME_TO_DEPLOY}";
            TestContext.WriteLine($"Checking file: {fileName}");

            fromCall = fileProcess.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check if a file does NOT exist.")]
        [Owner("EduardoCM")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            fromCall = fileProcess.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [Description("Check if a file path has been informed. If NO, throws an exception like ArgumentNullException.")]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("EduardoCM")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            var fileProcess = new FileProcess();
            fileProcess.FileExists(string.Empty);
        }

        [TestMethod]
        [Owner("EduardoCM")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            var fileProcess = new FileProcess();

            try
            {
                fileProcess.FileExists(string.Empty);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Fail expected.");
        }

        [TestMethod]
        [Timeout(3100)]
        public void SimulateTimeout()
        {
            Thread.Sleep(3000);
        }

        #endregion

        #region Helper Methods

        private void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                _GoodFileName = _GoodFileName.Replace("[AppPath]", folderPath);
            }
        }

        #endregion
    }
}