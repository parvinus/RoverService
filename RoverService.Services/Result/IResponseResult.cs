using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoverService.Services.Result
{
    public interface IResponseResult
    {
        string Message { get; set; }

        string  CurrentPosition { get; set; }

        string ToString();
    }
}
