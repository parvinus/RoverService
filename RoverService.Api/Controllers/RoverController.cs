using System.Net.Http;
using System.Web.Http;

namespace RoverService.Api.Controllers
{
    [RoutePrefix("api/Rover")]
    public class RoverController : ApiController
    {

        [Route("RetrievePosition")]
        [HttpGet]
        public HttpResponseMessage RetrievePosition(string roverId)
        {
            var roverService = new Services.RoverService.RoverService();
            return roverService.RetrievePosition(roverId);
        }

        [Route("UpdateMovement")]
        [HttpPost]
        public HttpResponseMessage UpdateMovement(string roverId, string movementInstructions)
        {
            var roverService = new Services.RoverService.RoverService();
            return roverService.UpdateMovement(roverId, movementInstructions);
        }
    }
}
