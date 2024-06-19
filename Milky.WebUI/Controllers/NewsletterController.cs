using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.DTOs.Newsletter;
using Milky.WebUI.DTOs.Product;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Controllers;
public class NewsletterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NewsletterController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpPost]
    public async Task<IActionResult> Create(ResultNewsletterDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44320/api/Newsletter", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }
        return RedirectToAction("Index", "Default");
    }
}
