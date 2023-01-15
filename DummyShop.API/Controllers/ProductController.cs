using DummyShop.Service.ProductClients;
using DummyShop.Service.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductClient _client;
        public ProductController(IProductClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _client.GetAllProduct();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByProductId(int id)
        {
            var response = await _client.GetProductById(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RootViewModel root)
        {
           
            var response = await _client.Create(root);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(RootViewModel root, int id)
        {

            var response = await _client.Update(root,id);

            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Deleted(int id)
        {
            var response = await _client.Delete(id);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Searched(string q)
        {
            var response = await _client.Search(q);
            return Ok(response);
        }
    }
}
