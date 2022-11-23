using APIVersionControl.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIVersionControl.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string ApiTestURL = "https://dummyapi.io/data/v1/user?limit=10";
        private const string AppID = "637d05a1c4ad643195d741d6";
        private readonly HttpClient _httpClient;

        public UsersController(HttpClient httpClient) { _httpClient = httpClient; }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetUsersData")]
        public async Task<IActionResult> GetUsersDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("app-id", AppID);

            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var usersData = await JsonSerializer.DeserializeAsync<UsersResponseData>(response);
            return Ok(usersData);
        }
    }
}
