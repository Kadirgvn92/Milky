using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.DTOs.Contact;
using Milky.WebUI.DTOs.Product;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultFooterPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultFooterPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Contact");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
