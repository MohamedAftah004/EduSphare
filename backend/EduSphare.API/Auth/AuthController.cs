using EduSphare.API.Auth.Contracts;
using EduSphare.Application.Auth.Register;
using EduSphare.Application.Auth.ResendVerification;
using EduSphare.Application.Auth.VerifyEmail;
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


        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail(
            VerifyEmailRequest request,
            CancellationToken cancellationToken)
        {
            var command = new VerifyEmailCommand(
                request.Email,
                request.Code);

            var result = await _sender.Send(
                command,
                cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(new
            {
                Message = "Email verified successfully."
            });
        }

        [HttpPost("resend-verification")]
        public async Task<IActionResult> ResendVerification(
            ResendVerificationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ResendVerificationCommand(
                request.Email);

            var result = await _sender.Send(
                command,
                cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(new
            {
                Message = "Verification code has been sent."
            });
        }
    }
}
