using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverService.Services.Response;
using RoverService.Services.Result;

namespace RoverService.Tests.Response
{
    public class MockResponseContent : IResponseContent
    {
        public MockResponseContent(string message, List<string> errors, IResponseResult result)
        {
            Message = message;
            Errors = errors;
            Result = result;
        }

        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public IResponseResult Result { get; set; }

        public override string ToString()
        {
            return "MockResponseContent";
        }
    }
}
