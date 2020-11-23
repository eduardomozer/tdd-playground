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
            if (TestContext.TestName.StartsWith(nameof(FileNameDoesExists_Test)))
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
            if (TestContext.TestName.StartsWith(nameof(FileNameDoesExists_Test)))
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
        [Owner("Eduardo")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists_Test()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fileProcess.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesExistsSimpleMessage_Test()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fileProcess.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File Does NOT Exists");
        }

        [TestMethod]
        public void FileNameDoesExistsMessageFormatting_Test()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fileProcess.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File {0} Does NOT Exists", _GoodFileName);
        }

        [TestMethod]
        [Owner("Eduardo")]
        [DeploymentItem(FILE_NAME_TO_DEPLOY)]
        public void FileNameDoesExistsDeploymentItem_Test()
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
        [Owner("Eduardo")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists_Test()
        {
            var fileProcess = new FileProcess();
            bool fromCall;

            fromCall = fileProcess.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("Eduardo")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_Test()
        {
            var fileProcess = new FileProcess();
            fileProcess.FileExists(string.Empty);
        }

        [TestMethod]
        [Owner("Eduardo")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch_Test()
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
        public void SimulateTimeout_Test()
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