using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DataContracts.auth;
using SocialNetwork.domain;
using SocialNetwork.domain.users;
using SocialNetwork.infrastructure.helpers;
using SocialNetwork.services;
using SocialNetwork.services.exceptions;
using RegisterRequest = SocialNetwork.DataContracts.auth.RegisterRequest;
using Sex = SocialNetwork.domain.Sex;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserRepository userRepository) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {
            if (!Validator.IsEmailValid(request.Email))
                return BadRequest(new BaseResponse());

            if (string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Password is incorrect or empty");

            if (await userRepository.IsUserWithEmailExist(request.Email))
            {
                return BadRequest($"User with email {request.Email} already exists");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthday = request.Birthday,
                City = request.City,
                AboutMe = request.AboutMe,
                Sex = (Sex)request.Sex,
                PasswordHash = PasswordHashHelper.HashPassword(request.Password)
            };

            await userRepository.AddUser(user);

            return Ok(new BaseResponse(Error: $"User with {request.Email} is registered"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, [FromServices] IUserManageService userManageService)
        {
            if (request.Email == null) throw new ArgumentNullException(nameof(request.Email));
            if (request.Password == null) throw new ArgumentNullException(nameof(request.Password));

            try
            {
                return Ok(new BaseResponse(await userManageService.Login(request)));
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(new BaseResponse(Error: e.Message));
            }
            catch (WrongLoginDataException e)
            {
                return BadRequest(new BaseResponse(Error: e.Message));
            }
        }
    }
}