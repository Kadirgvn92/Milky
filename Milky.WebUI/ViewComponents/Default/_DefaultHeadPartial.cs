using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.DTOs.Product;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultHeadPartial : ViewComponent
{
	
	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View();
	}
}
