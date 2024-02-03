using API.Data;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRespository _userRespository;
        private readonly IMapper _mapper;
        public UsersController(IUserRespository userRespository, IMapper mapper)
        {
            _mapper = mapper;
            _userRespository = userRespository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRespository.GetUsersAsync();

            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{username}")] // api/users/username
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await _userRespository.GetUserByUsernameAsync(username);

            return _mapper.Map<MemberDto>(user);
        }
    }
}
