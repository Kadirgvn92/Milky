using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents.AdminLayout;

public class _AdminScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
