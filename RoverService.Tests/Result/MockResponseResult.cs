using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoverService.Services.Result;

namespace RoverService.Tests.Result
{
    class MockResponseResult : IResponseResult
    {
        public string Message { get; set; }
        public string CurrentPosition { get; set; }

        public MockResponseResult()
        {
            
        }
        public MockResponseResult(string message, string currentPosition)
        {
            Message = message;
            CurrentPosition = currentPosition;
        }

        public override string ToString()
        {
            return "MockResponseResult";
        }
    }
}
