using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoverService.Services.Validators
{
    public static class ServiceValidators
    {
        public static bool ValidateRoverId(string roverId, out string message)
        {
            if (String.IsNullOrEmpty(roverId) || roverId.Length > 10)
            {
                message = "RoverId provided is not valid.  An ID must be between 1 and 10 alphanumeric characters.";
                return false;
            }

            if (Regex.IsMatch(roverId, @"\W | _"))
            {
                message = "RoverId provided is not valid.  An ID must only contain numbers and letters. " ;
                return false;
            }

            message = "valid";
            return true;
        }

        public static bool ValidateMovementInstructions(string movementInstructions, out string message)
        {
            if (String.IsNullOrEmpty(movementInstructions) || movementInstructions.Length > 100)
            {
                message = "movementInstructions provided are not valid.  An instruction must be between 1 and 100 characters in length.";
                return false;
            }

            if (Regex.IsMatch(movementInstructions, "[^RrLlMm]"))
            {
                message = "movementInstructions provided is not valid.  Instructions must only contain the letters \"R\" \"L\" or \"M\".";
                return false;
            }

            message = "valid";
            return true;
        }
    }
}
