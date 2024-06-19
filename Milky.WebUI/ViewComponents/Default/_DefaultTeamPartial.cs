using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.DTOs.Employee;
using Milky.WebUI.DTOs.Product;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Default;

public class _DefaultTeamPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultTeamPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Employee");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
