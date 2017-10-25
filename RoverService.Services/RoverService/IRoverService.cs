using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoverService.Services.RoverService
{
    public interface IRoverService
    {
        HttpResponseMessage RetrievePosition(string roverId);

        HttpResponseMessage UpdateMovement(string roverId, string movementInstructions);
    }
}
