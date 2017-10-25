using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoverService.Tests.Result
{
    [TestClass]
    public class MockResponseResultTests
    {
        private MockResponseResult _mockResponseResult;
        private string _currentPosition = "currentposition";
        private string _message = "message";

        [TestMethod]
        public void TestConstructors()
        {
            _mockResponseResult = new MockResponseResult(_message, _currentPosition);

            //test that constructor properly mapped the data
            Debug.Assert(_mockResponseResult.Message == _message);
            Debug.Assert(_mockResponseResult.CurrentPosition == _currentPosition);
        }

        [TestMethod]
        public void TestToString()
        {
            _mockResponseResult = new MockResponseResult(_message, _currentPosition);
            Debug.Assert(_mockResponseResult.ToString() == "MockResponseResult");
        }
    }
}
