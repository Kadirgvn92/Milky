using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.DTOs.Product;
using Milky.WebUI.DTOs.Services;
using Milky.WebUI.DTOs.Statistic;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultFeaturePartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultFeaturePartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Statistic");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultStatisticDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
