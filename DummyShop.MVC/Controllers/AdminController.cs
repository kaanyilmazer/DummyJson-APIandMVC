using Microsoft.AspNetCore.Mvc;

namespace DummyShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult NewSideBar()
        {
            return PartialView();
        }
    }
}
