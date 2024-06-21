using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Areas.Admin.Models;
using Milky.WebUI.DTOs.Services;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]

public class ServicesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ServicesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public string GenerateName()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        Random random = new Random();
        char[] stringChars = new char[6];

        for (int i = 0; i < 6; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Services");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
          

            return View(values);
        }
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ResultServiceDto dto)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(dto.Image.FileName);
        var imagename = GenerateName() + extension;
        var savelocation = Path.Combine(resource, "wwwroot/ServicesImages", imagename);

        using (var stream = new FileStream(savelocation, FileMode.Create))
        {
            await dto.Image.CopyToAsync(stream);
        }
        dto.BackgroundImageUrl = imagename;


        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44320/api/Services", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Services/GetServicesById?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultServiceDto>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Update(ResultServiceDto dto)
    {
        var client = _httpClientFactory.CreateClient();

        // API'den mevcut ürün verilerini al
        var responseMessage = await client.GetAsync($"https://localhost:44320/api/Services/GetServicesById?id=" + dto.ID);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var existingServices = JsonConvert.DeserializeObject<ResultServiceDto>(jsonData);

        // Yeni resim yüklenmişse işle
        if (dto.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(dto.Image.FileName);
            var imagename = GenerateName() + extension;
            var savelocation = Path.Combine(resource, "wwwroot/servicesImages", imagename);

            using (var stream = new FileStream(savelocation, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }
            dto.BackgroundImageUrl = imagename;
        }
        else
        {
            dto.BackgroundImageUrl = existingServices.BackgroundImageUrl;
        }

        // Güncellenen verileri JSON'a dönüştür
        var updatedServicesJson = JsonConvert.SerializeObject(dto);
        var stringContent = new StringContent(updatedServicesJson, Encoding.UTF8, "application/json");

        // Güncelleme isteğini API'ye gönder
        var updateResponse = await client.PutAsync("https://localhost:44320/api/Services/", stringContent);

        if (updateResponse.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View(dto); // Hata durumunda aynı sayfayı yeniden yükleyin
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:44320/api/Services?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
