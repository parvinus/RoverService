using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverService.Services.Result;

namespace RoverService.Tests.Response
{
    [TestClass]
    public class MockResponseContentTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var errors = new List<string> {"error"};

            var mockResponseContent = new MockResponseContent(
                "message", errors, new ResponseResult("message", "currentposition"));
            Debug.Assert(mockResponseContent.Message == "message");
            Debug.Assert(mockResponseContent.Errors != null && mockResponseContent.Errors.Contains("error"));
            Debug.Assert(mockResponseContent.Result != null && mockResponseContent.Message == "message");
            Debug.Assert(mockResponseContent.Result.CurrentPosition == "currentposition");
        }

        [TestMethod]
        public void TestToString()
        {
            var errors = new List<string> { "error" };
            var result = new ResponseResult("message", "currentposition");
            var message = "responsecontentmessage";


            var responseContent = new MockResponseContent(message, errors, result);
            Debug.Assert(responseContent.ToString() == "MockResponseContent");
        }
    }
}
