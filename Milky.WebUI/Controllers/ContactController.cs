using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Controllers;
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
