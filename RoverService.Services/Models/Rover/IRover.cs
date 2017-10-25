using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoverService.Services.Shared.Enums;

namespace RoverService.Services.Rover
{
    public interface IRover
    {
        string RoverId { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        CardinalDirection Direction { get; set; }

        void Turn(char instruction);
        string RetrievePosition();
        void Move();
    }
}
