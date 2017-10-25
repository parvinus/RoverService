using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RoverService.Services.Result;

namespace RoverService.Services.Response
{
    public interface IResponseContent
    {
        string Message { get; set; }

        List<string> Errors { get; set; }
        
        IResponseResult Result { get; set; }

    }
}
