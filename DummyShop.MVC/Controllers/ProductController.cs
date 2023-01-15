using DummyShop.Service.ProductClientsWEB;
using DummyShop.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DummyShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebProductClient _client;

        public ProductController(IWebProductClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var all = await _client.GetAllProduct();
            return View(all);
        }

        [HttpDelete]
        public async Task<IActionResult> Deleted(int id)
        {
            var values = await _client.Delete(id);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var values = await _client.GetProductById(id);
            return View(values);
        }

   
    }
}
