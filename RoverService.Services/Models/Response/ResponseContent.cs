using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoverService.Services.Result;

namespace RoverService.Services.Response
{
    public class ResponseContent : IResponseContent
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public IResponseResult Result { get; set; }

        /// <summary>
        ///     constructor to inject dependencies into this class
        /// </summary>
        /// <param name="message">A string containing a useful message regarding what happened with the request</param>
        /// <param name="errors">A list of strings containing error messages related to the request</param>
        /// <param name="result">the result of the request in a format the requestor is expecting</param>
        public ResponseContent(string message, List<string> errors, IResponseResult result)
        {
            Message = message;
            Errors = errors;
            Result = result;
        }

        /// <summary>
        ///     override ToString method to serialize this object and return that.
        /// </summary>
        /// <returns>string representing a serialized copy of this object</returns>
        public override string ToString()
        {
            try
            {
                //throw new Exception("testing catch block");
                return JsonConvert.SerializeObject(this);
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
                return "";
            }
        }

    }
}
