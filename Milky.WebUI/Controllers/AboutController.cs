using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Controllers;
public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
