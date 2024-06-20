using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Areas.Admin.Models;
using Milky.WebUI.DTOs.About;
using Milky.WebUI.DTOs.About;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Milky.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class AboutController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public AboutController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/About");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

            return View(values);
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/About/GetAboutById?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Update(ResultAboutDto dto)
    {
        var client = _httpClientFactory.CreateClient();

        // API'den mevcut ürün verilerini al
        var responseMessage = await client.GetAsync($"https://localhost:44320/api/About/GetAboutById?id=" + dto.ID);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var existingAbout = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);

        // Güncellenen verileri JSON'a dönüştür
        var updatedAboutJson = JsonConvert.SerializeObject(dto);
        var stringContent = new StringContent(updatedAboutJson, Encoding.UTF8, "application/json");

        // Güncelleme isteğini API'ye gönder
        var updateResponse = await client.PutAsync("https://localhost:44320/api/About/", stringContent);

        if (updateResponse.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View(dto); // Hata durumunda aynı sayfayı yeniden yükleyin
    }
}
