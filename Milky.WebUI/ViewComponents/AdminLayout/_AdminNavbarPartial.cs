using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents.AdminLayout;

public class _AdminNavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
