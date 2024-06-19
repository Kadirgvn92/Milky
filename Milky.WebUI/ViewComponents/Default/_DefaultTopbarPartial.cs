using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultTopbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
