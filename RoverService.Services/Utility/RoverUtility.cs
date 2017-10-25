using System.Collections.Generic;
using RoverService.Services.Shared.Enums;

namespace RoverService.Services.Utility
{
    public class RoverUtility
    {
        public static LinkedList<CardinalDirection> GetCardinalDirections()
        {

            var directions = new LinkedList<CardinalDirection>();

            directions.AddFirst(CardinalDirection.North);
            directions.AddLast(CardinalDirection.East);
            directions.AddLast(CardinalDirection.South);
            directions.AddLast(CardinalDirection.West);

            return directions;
        }
    }
}
