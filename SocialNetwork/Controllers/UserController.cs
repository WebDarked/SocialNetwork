using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DataContracts.auth;
using SocialNetwork.services;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id, [FromServices] IUserManageService userManageService)
        {
            if (!await userManageService.IsUserExist(id))
                return BadRequest(new BaseResponse(Error: $"User with id = {id} is not found"));
            
            var userProfile = await userManageService.GetUserProfile(id);
            return Ok(userProfile);
        }
    }
}
