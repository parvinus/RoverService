using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoverService.Services.Result
{
    public class ResponseResult : IResponseResult
    {
        public string Message { get; set; }
        public string CurrentPosition { get; set; }

        public ResponseResult() { }

        public ResponseResult(string message, string currentPosition)
        {
            Message = message;
            CurrentPosition = currentPosition;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
