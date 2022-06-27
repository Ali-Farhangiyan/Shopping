
using Microsoft.AspNetCore.Mvc;

namespace ShoppingUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
