using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DataContracts.auth;
using SocialNetwork.domain;
using SocialNetwork.domain.users;
using System.Text.RegularExpressions;
using SocialNetwork.infrastructure.helpers;
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
                return BadRequest("Email is not valid");

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
                Sex = (Sex)request.Sex
            };

            userRepository.RegisterUser(user);

            return Ok(new RegisterResponse());
        }
    }
}
