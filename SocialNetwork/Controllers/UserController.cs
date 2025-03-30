using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute]Guid userId)
        {
            
            return await Task.FromResult<IActionResult>(Ok());
        }
    }
}
