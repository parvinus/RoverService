using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoverService.Data.Dto;
using RoverService.Services.Shared.Enums;
using RoverService.Services.Utility;
using RoverService.Services.Validators;

namespace RoverService.Services.Rover
{
    public class Rover : IRover
    {
        #region constants

        private readonly LinkedList<CardinalDirection> _turnDirections = RoverUtility.GetCardinalDirections();
        #endregion

        #region properties
        public string RoverId { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public CardinalDirection Direction { get; set; }
        #endregion

        #region constructors

        public Rover()
        {

        }

        public Rover(string roverId)
        {
            RoverId = roverId;



            //TODO: get rover object by id provided and populate this rover with its values.

            //_turnDirections = RoverUtility.GetCardinalDirections();
        }

        public Rover(RoverDto roverDto)
        {
            Direction = (CardinalDirection) roverDto.Direction;
            PositionX = roverDto.PositionX;
            PositionY = roverDto.PositionY;
            RoverId = roverDto.RoverId;

        }
        #endregion

        #region methods

        /// <summary>
        ///     returns position values as a formatted string.
        /// </summary>
        /// <returns>
        ///     position values as a formatted string.
        /// </returns>
        public string RetrievePosition()
        {
            return $"({PositionX}, {PositionY})";
        }

        /// <summary>
        ///     given a movement instruction, this method attempts to move the rover.
        /// </summary>
        /// <param name="movementInstruction">
        ///     a string representing a single movement instruction
        /// </param>
        public void Turn(char movementInstruction)
        {
            var newDirection = _turnDirections.Find(Direction);

            if (movementInstruction == 'L')
                Direction = newDirection?.Previous?.Value ?? Direction;
            else if (movementInstruction == 'R')
                Direction = _turnDirections.Find(Direction)?.Next?.Value ?? Direction;
        }

        /// <summary>
        ///     updates the rover's position values based on current direction
        /// </summary>
        public void Move()
        {
            switch (Direction)
            {
                case CardinalDirection.North:
                    PositionY += 1;
                    break;
                case CardinalDirection.South:
                    PositionY -= 1;
                    break;
                case CardinalDirection.East:
                    PositionX += 1;
                    break;
                case CardinalDirection.West:
                    PositionX -= 1;
                    break;
            }
        }

        #endregion
    }
}
