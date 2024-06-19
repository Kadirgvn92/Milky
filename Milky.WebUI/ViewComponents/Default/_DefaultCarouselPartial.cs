using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.DTOs.Product;
using Milky.WebUI.DTOs.Slider;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultCarouselPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultCarouselPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
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
