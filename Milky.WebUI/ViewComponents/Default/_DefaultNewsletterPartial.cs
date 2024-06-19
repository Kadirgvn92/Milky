using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.DTOs.Newsletter;
using Milky.WebUI.DTOs.Testimonial;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultNewsletterPartial : ViewComponent
{
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
