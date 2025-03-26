using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Datacontracts.auth;
using SocialNetwork.domain;
using SocialNetwork.domain.auth;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthRepository authRepository) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(RegisterRequest request)
        {
            if (await authRepository.IsUserWithEmailExist(request.Email))
            {
                return BadRequest("User already exists");
            }

            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthday = request.Birthday,
                City = request.City,
                AboutMe = request.AboutMe
            };

            await authRepository.RegisterUser(user);

            return Ok(new RegisterResponse());
        }
    }
}
