using LibraryApi.Entities;
using LibraryApi.Models.AuthenticateModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services.AuthenticationService;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryApi.Controllers
{

    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;

        public AuthenticationController(IAuthenticationServices authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequestBodyDto request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await _authenticationService.Login(request.UserName, request.Password);
            if (user == null) return Unauthorized();

            return Ok(new { message = $"Hello {user.FirstName}", token = user.Token });
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] LibraryUsersDto model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userToSignUp = new User(
                model.UserName, model.FirstName, model.LastName,
                model.UserEmail, model.UserPhone, model.City, model.Password);

            var signedUpUser = await _authenticationService.SignUp(userToSignUp);
            if (signedUpUser == null)
                return BadRequest(new { message = "Username already exists" });

            var loggedInUser = await _authenticationService.Login(signedUpUser.UserName, signedUpUser.Password);
            return Ok(loggedInUser);
        }
      
    }
}

