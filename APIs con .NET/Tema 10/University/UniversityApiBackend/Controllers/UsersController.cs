using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Extensions;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniversityDBContext _dbContext;
        private readonly ILogger<UsersController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(UniversityDBContext dbContext, ILogger<UsersController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                _logger.LogInformation("{Controller} - {CallMethod}", nameof(UsersController), nameof(GetUser));
                _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
                _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

                if (_dbContext.Users == null)
                {
                    _logger.LogCritical("Critical error: Users resource not found!");

                    return NotFound();
                }

                _logger.LogInformation("Id param: {Id}", id);

                var user = await _dbContext.Users.FindAsync(id);

                if (user == null)
                {
                    _logger.LogInformation("User {UserId} not found", id);

                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("User {UserId} found", id);
                }

                _logger.LogInformation("Returning user...");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error trying to get user: {Message}", ex.Message);
                _logger.LogError("Inner exception: {InnerException}", ex.InnerException);
                _logger.LogError("Stack trace: {StackTrace}", ex.StackTrace);

                throw new Exception("GetUser Error", ex);
            }
          
        }

        // Admin only
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            using (LogContext.PushProperty("Id", id))
            {
                _logger.LogInformation("{Controller} - {CallMethod}", nameof(UsersController), nameof(PutUser));
                _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
                _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor?.HttpContext?.Request.Headers);
                _logger.LogInformation("Id param = {Id}");
                _logger.LogInformation("Request body = {@RequestBody}", user);

                if (id != user.Id)
                {
                    _logger.LogInformation("Bad request: invalid user id");
                    return BadRequest();
                }
                else
                {
                    _logger.LogInformation("User {Id} found");
                }

                _dbContext.Entry(user).State = EntityState.Modified;

                try
                {
                    _logger.LogInformation("Saving updated user...");
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    _logger.LogInformation("Catched {DbUpdateConcurrencyException}", typeof(DbUpdateConcurrencyException));
                    if (!UserExists(id))
                    {
                        _logger.LogInformation("User {Id} not found");
                        return NotFound();
                    }
                    else
                    {
                        _logger.LogError("Db Update Concurrency Exception");
                        throw;
                    }
                }
            }

            return NoContent();
        }

        // Admin only
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(UsersController), nameof(PutUser));
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor?.HttpContext?.Request.Headers);

            if (_dbContext.Users == null)
          {
              return Problem("Entity set 'UniversityDBContext.Users'  is null.");
          }
            _dbContext.Users.Add(user);
            try
            {
                _logger.LogInformation("Saving updated user...");
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error trying to get user: {Message}", ex.Message);
                _logger.LogError("Inner exception: {InnerException}", ex.InnerException);
                _logger.LogError("Stack trace: {StackTrace}", ex.StackTrace);

                throw new Exception("PostUser Error", ex);
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // Admin only
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(UsersController), nameof(PutUser));
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());

            if (_dbContext.Users == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Id param: {UserId}", id);

            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogInformation("User {Id} not found", id);
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Saving updated user...");

            } catch (Exception ex)
            {
                _logger.LogError("Error trying to get user: {Message}", ex.Message);
                _logger.LogError("Inner exception: {InnerException}", ex.InnerException);
                _logger.LogError("Stack trace: {StackTrace}", ex.StackTrace);
            }
                

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_dbContext.Users?.Any(user => user.Id == id)).GetValueOrDefault();
        }
    }
}
