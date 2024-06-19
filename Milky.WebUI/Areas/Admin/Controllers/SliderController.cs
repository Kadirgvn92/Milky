using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milky.WebUI.Areas.Admin.Models;
using Milky.WebUI.DTOs.Product;
using Milky.WebUI.DTOs.Slider;
using Newtonsoft.Json;

namespace Milky.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class SliderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SliderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Slider");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
