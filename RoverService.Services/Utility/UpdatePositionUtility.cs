using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using RoverService.Data.Dto;
using RoverService.Services.Rover;
using RoverService.Services.Shared.Enums;
using RoverService.Services.Validators;

namespace RoverService.Services.Utility
{
    public class UpdatePositionUtility
    {
        public static RoverDto UpdatePosition(IRover rover, string movementInstructions)
        {
            var message = "";

            if (ServiceValidators.ValidateMovementInstructions(movementInstructions, out message))
            {
                var instructionAsCharArray = movementInstructions.ToUpper().ToCharArray();

                foreach (var instruction in instructionAsCharArray)
                {
                    if (instruction == 'M')
                        rover.Move();
                    else rover.Turn(instruction);
                }
            }

           return new RoverDto()
            {
                Direction = (int) rover.Direction,
                PositionX = rover.PositionX,
                PositionY = rover.PositionY,
                RoverId = rover.RoverId
            };
        }
    }
}
