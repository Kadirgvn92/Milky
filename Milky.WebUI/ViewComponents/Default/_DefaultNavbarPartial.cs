using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultNavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
