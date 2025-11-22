using LibraryApi.Entities;
using LibraryApi.Models.AuthenticateModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services.AuthenticationService;

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
            public async Task<IActionResult> Login(AuthenticationRequestBodyDto authenticationRequestBody)
            {
                if (authenticationRequestBody.UserName == null)
                {
                    return BadRequest(new { mesaage = "Please Enter UserName" });
                }
                if (authenticationRequestBody.Password == null)
                {
                    return BadRequest(new { mesaage = "Please Enter Password" });
                }
                User? userToLogin =
                    await _authenticationService.Login(authenticationRequestBody.UserName, authenticationRequestBody.Password);
                if (userToLogin != null)
                {
                    return Ok($"Hello {userToLogin.FirstName} \n your token is : {userToLogin.Token}");

                }
                return NotFound();


            }
            [HttpPost("signup")]
            public async Task<IActionResult> SignUp([FromBody] LibraryUsersDto libraryUser)
            {
                if (libraryUser.UserName == null)
                {
                    return BadRequest(new { message = "Please Enter UserName" });
                }
                if (libraryUser.Password == null)
                {
                    return BadRequest(new { message = "Please Enter Password " });
                }
                if (libraryUser.UserEmail == null)
                {
                    return BadRequest(new { message = "Please Enter Email " });
                }
                if (libraryUser.FirstName == null)
                {
                    return BadRequest(new { message = "Please Enter FirstName " });
                }
                if (libraryUser.LastName == null)
                {
                    return BadRequest(new { message = "Please Enter LastName " });
                }
                if (libraryUser.City == null)
                {
                    return BadRequest(new { message = "Please Enter Your City " });
                }
                if (libraryUser.UserPhone == null)
                {
                    return BadRequest(new { message = "Please Enter Your Phone Number " });
                }

                User userToSignUp =
                    new User(libraryUser.UserName, libraryUser.FirstName, libraryUser.LastName
                    , libraryUser.UserEmail, libraryUser.UserPhone, libraryUser.City, libraryUser.Password);

                User signedUpUser = await _authenticationService.SignUp(userToSignUp);
                if (signedUpUser == null) { return BadRequest(new { message = "Please Chaange UserName" }); }

                User UserToLogin = await _authenticationService.Login(signedUpUser.UserName, signedUpUser.Password);
                if (UserToLogin == null) { return NotFound(); }

                return Ok(UserToLogin);

            }
        }
    }

