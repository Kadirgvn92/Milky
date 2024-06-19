using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultGalleryPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
