using DummyShop.Service.ProductClientsWEB;
using DummyShop.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DummyShop.MVC.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IWebProductClient _client;

        public AdminProductController(IWebProductClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var all = await _client.GetAllProduct();
            return View(all);
        }


        public async Task<IActionResult> Deleted(int id)
        {
            var values = await _client.Delete(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var values = await _client.GetProductById(id);
            return View(values);
        }

        //[HttpPost]
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(RootViewModel model)
        {
            var values = await _client.Add(model);
            return RedirectToAction("Index");
        }
    }
}