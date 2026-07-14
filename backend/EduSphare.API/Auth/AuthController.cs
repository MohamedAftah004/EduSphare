using EduSphare.API.Auth.Requests;
using EduSphare.Application.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduSphare.API.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            var command = new RegisterCommand(
                request.FirstName,
                request.LastName,
                request.Username,
                request.Email,
                request.Password
                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result);
        }
    }
}
