using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents.AdminLayout;

public class _AdminFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
