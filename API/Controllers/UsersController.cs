using API.Data;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRespository _userRespository;
        public UsersController(IUserRespository userRespository)
        {
            _userRespository = userRespository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return Ok(await _userRespository.GetUsersAsync());
        }

        [HttpGet("{username}")] // api/users/username
        public async Task<ActionResult<AppUser>> GetUser(string username)
        {
            return await _userRespository.GetUserByUsernameAsync(username);
        }
    }
}
