using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RoverService.Data.Dto;
using RoverService.Data.Repository;
using RoverService.Services.Response;
using RoverService.Services.Result;
using RoverService.Services.Utility;
using RoverService.Services.Validators;

namespace RoverService.Services.RoverService
{
    public class RoverService : IRoverService
    {
        private readonly IRepository<RoverDto> _roverRepository;

        public RoverService()
        {
            _roverRepository = new Repository();
        }

        public HttpResponseMessage RetrievePosition(string roverId)
        {
            var responseMessage = "";
            var errors = new List<string>();
            var message = "";
            HttpStatusCode code;
            var position = "";

            if (!ServiceValidators.ValidateRoverId(roverId, out message))
            {
                responseMessage = "Invalid Request";
                errors.Add(message);
                code = HttpStatusCode.BadRequest;
            }
            else
            {
                var rover = _roverRepository.GetById(roverId);

                if (rover == null || string.IsNullOrEmpty(rover.RoverId))
                {                   
                    responseMessage = "No rover matching the given id was found.";
                }
                else
                {
                    responseMessage = "Position retrieved successfully";
                    position = $"({rover.PositionX}, {rover.PositionY})";
                }
                code = HttpStatusCode.OK;
            }
            
            var responseResult = new ResponseResult(message, position);
            var responseContent = new ResponseContent(responseMessage, errors, responseResult);
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(responseContent.ToString()),
                ReasonPhrase = responseMessage,
                StatusCode = code
            };

            return response;
        }

        public HttpResponseMessage UpdateMovement(string roverId, string movementInstructions)
        {
            var responseMessage = "";
            var errors = new List<string>();
            var message = "";
            HttpStatusCode code;
            var position = "";

            if (!ServiceValidators.ValidateMovementInstructions(movementInstructions, out message))
            {
                responseMessage = "Invalid Request";
                errors.Add(message);
                code = HttpStatusCode.BadRequest;
            }
            else
            {
                var roverDto = _roverRepository.GetById(roverId) ?? new RoverDto()
                {
                    RoverId = roverId
                };

                if (String.IsNullOrEmpty(roverDto.RoverId))
                {
                    responseMessage = "Invalid RoverId provided";
                }
                else
                {
                    var rover = new Rover.Rover(roverDto);

                    roverDto = UpdatePositionUtility.UpdatePosition(rover, movementInstructions);
                    _roverRepository.Set(roverDto);

                    responseMessage = "Position updated successfully";
                    position = $"({rover.PositionX}, {rover.PositionY})";
                }
                code = HttpStatusCode.OK;
            }

            var responseResult = new ResponseResult(message, position);
            var responseContent = new ResponseContent(responseMessage, errors, responseResult);
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(responseContent.ToString()),
                ReasonPhrase = responseMessage,
                StatusCode = code
            };

            return response;
        }
    }
}
