using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Serilog.Context;
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
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountController(UniversityDBContext dBContext, JwtSettings jwtSettings, IStringLocalizer<AccountController> stringLocalizer, ILogger<AccountController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dBContext;
            _jwtSettings = jwtSettings;
            _stringLocalizer = stringLocalizer;
            _logger = logger;
            _contextAccessor = httpContextAccessor;
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserToken>>> GetToken(UserLogin userLogin)
        {
            try
            {

                _logger.LogInformation("{Controller} - {CallMethod}", nameof(AccountController), nameof(GetToken));

                _logger.LogInformation("Request info: {Headers}", _contextAccessor.HttpContext?.Request.Headers);
                
                var Token = new UserToken();

                if (_dbContext.Users == null)
                {
                    _logger.LogCritical("Critical error: Users resource not found!");
                    return NotFound();
                }

                var Valid = await _dbContext.Users.AnyAsync(user => user.Username.Equals(userLogin.Username)
                                                               && user.Password.Equals(userLogin.Password));

                if (Valid)
                {
                    _logger.LogInformation("User {Username} is valid", userLogin.Username);

                    var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username.Equals(userLogin.Username));

                    using (LogContext.PushProperty("UserId", user!.Id))
                    {
                        _logger.LogInformation("User {UserId} logged in");
                    

                        var message = string.Format(_stringLocalizer.GetString("Welcome"), user!.FirstName);

                        Token = JwtHelpers.GenTokenKey(new UserToken()
                        {
                            Username = user!.Username,
                            EmailId = user.Email,
                            Id = user.Id, 
                            GuidId = Guid.NewGuid(),
                            Role = user.Role.ToString(),
                            WelcomeMessage = message
                        },  _jwtSettings);

                        _logger.LogInformation("Token created for user {UserId}: {Token}", User, Token);
                    }

                    _logger.LogInformation("Returning token...");
                    return Ok(Token);
                }
                else
                {
                    _logger.LogInformation("Login info is invalid");
                    return BadRequest("Wrong username or password");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error trying to log in: {Message}", ex.Message);
                _logger.LogError("Inner exception: {InnerException}", ex.InnerException);
                _logger.LogError("Stack trace: {StackTrace}", ex.StackTrace);

                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(AccountController), nameof(GetUsers));

            if (_dbContext.Users == null)
            {
                _logger.LogCritical("Critical error: Users resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Request info: {Headers} ", _contextAccessor.HttpContext?.Request.Headers);
            
            string Role = string.Empty;
            if(_contextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var Authorization)){
                Role = Authorization;
                _logger.LogInformation("Request role: {RequestRole}", Role);
            }
            else
            {
                _logger.LogInformation("Authorization header not provided");
            }
            

            try
            {
                return await _dbContext.Users.ToListAsync();
            }catch (Exception ex)
            {
                _logger.LogError("Error trying to get users: {Message}", ex.Message);
                _logger.LogError("Inner exception: {InnerException}", ex.InnerException);
                _logger.LogError("Stack trace: {StackTrace}", ex.StackTrace);

                throw new Exception("GetUsers exception", ex);
            }
            
        }
    }
}
