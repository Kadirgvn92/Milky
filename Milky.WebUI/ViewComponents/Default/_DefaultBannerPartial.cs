using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultBannerPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
