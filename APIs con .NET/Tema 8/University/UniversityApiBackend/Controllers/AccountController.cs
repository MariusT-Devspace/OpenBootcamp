using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _dbContext;
        private readonly JwtSettings _jwtSettings;
        private readonly IStringLocalizer<AccountController> _stringLocalizer;

        public AccountController(UniversityDBContext dBContext, JwtSettings jwtSettings, IStringLocalizer<AccountController> stringLocalizer)
        {
            _dbContext = dBContext;
            _jwtSettings = jwtSettings;
            _stringLocalizer = stringLocalizer;
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserToken>>> GetToken(UserLogin userLogin)
        {
            try
            {
                var Token = new UserToken();

                if (_dbContext.Users == null)
                {
                    return NotFound();
                }

                var Valid = await _dbContext.Users.AnyAsync(user => user.Username.Equals(userLogin.Username)
                                                               && user.Password.Equals(userLogin.Password));

                if (Valid)
                {
                    var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username.Equals(userLogin.Username));
                    var message = string.Format(_stringLocalizer.GetString("Welcome"), user!.FirstName);

                    Token = JwtHelpers.GenTokenKey(new UserToken()
                    {
                        Username = user!.Username,
                        EmailId = user.Email,
                        Id = user.Id, 
                        GuidId = Guid.NewGuid(),
                        Role = user.Role.ToString(),
                        WelcomeMessage = message
                    }, _jwtSettings);
                    return Ok(Token);
                }
                else
                {
                    return BadRequest("Wrong username or password");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }

            return await _dbContext.Users.ToListAsync();
        }
    }
}
