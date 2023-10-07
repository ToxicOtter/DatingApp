using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController (DataContext context){
            _context = context;
        }

        [HttpPost("register")] // api/account/register
        public async Task<ActionResult<AppUser>> Register (RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Username)) return BadRequest("Username is taken");
            
            using var hmac = new HMACSHA512(); // we use "using" here because the class have a dispose method, so when we are no using it anymore, the class is finished
            var user = new AppUser
            {
                UserName = registerDTO.Username.ToString(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }  
}
