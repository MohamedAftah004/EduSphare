using EduSphare.API.Auth.Contracts;
using EduSphare.Application.Auth.Login;
using EduSphare.Application.Auth.Register;
using EduSphare.Application.Auth.ResendVerification;
using EduSphare.Application.Auth.VerifyEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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



        //login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequest request,
            CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.Email, request.Password);
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return Unauthorized(result.Error);
            }

            var response = new Contracts.LoginResponse(
                result.Value.AccessToken,
                result.Value.RefreshToken);


            return Ok(response);
        }


        //test autohrize
        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(new
            {
                UserId = userId
            });
        }
    }

}
