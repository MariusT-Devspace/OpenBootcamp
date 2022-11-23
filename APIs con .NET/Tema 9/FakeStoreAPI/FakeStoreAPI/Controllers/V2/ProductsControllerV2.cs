using FakeStoreAPI.DTO.V2;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FakeStoreAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string FakeStoreUrl = "https://fakestoreapi.com/products";
    
        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "Products")] 
        public async Task<IActionResult> GetProductsAsync()
        {
            var response = await _httpClient.GetStreamAsync(FakeStoreUrl);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var products = await JsonSerializer.DeserializeAsync<Product[]>(response, options);
            return Ok(products);
        }
    }
}
