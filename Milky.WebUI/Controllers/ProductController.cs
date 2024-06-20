using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Controllers;
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
