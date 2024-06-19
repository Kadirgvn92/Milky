using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milky.WebUI.Areas.Admin.Models;
using Milky.WebUI.DTOs.Product;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text;

namespace Milky.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
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
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Product");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            var model = new ProductViewModel
            {
                Products = values,
                PageInfo = new PageInfoModel()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10, // Örnek olarak 10 ürün gösteriliyor olsun
                    TotalItems = values.Count(), // Örnek olarak toplam 100 ürün var olsun
                }
            };

            return View(model);
        }
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(createProductDto.Image.FileName);
        var imagename = GenerateName() + extension;
        var savelocation = Path.Combine(resource, "wwwroot/productImages", imagename);

        using (var stream = new FileStream(savelocation, FileMode.Create))
        {
            await createProductDto.Image.CopyToAsync(stream);
        }
        createProductDto.ImageUrl = imagename;


        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createProductDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44320/api/Product", stringContent);
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
        var responseMessage = await client.GetAsync("https://localhost:44320/api/Product/GetProductById?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
        var client = _httpClientFactory.CreateClient();

        // API'den mevcut ürün verilerini al
        var responseMessage = await client.GetAsync($"https://localhost:44320/api/Product/GetProductById?id=" + dto.ID);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var existingProduct = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

        // Yeni resim yüklenmişse işle
        if (dto.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(dto.Image.FileName);
            var imagename = GenerateName() + extension;
            var savelocation = Path.Combine(resource, "wwwroot/productImages", imagename);

            using (var stream = new FileStream(savelocation, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }
            dto.ImageUrl = imagename;
        }
        else
        {
            dto.ImageUrl = existingProduct.ImageUrl;
        }

        // Güncellenen verileri JSON'a dönüştür
        var updatedProductJson = JsonConvert.SerializeObject(dto);
        var stringContent = new StringContent(updatedProductJson, Encoding.UTF8, "application/json");

        // Güncelleme isteğini API'ye gönder
        var updateResponse = await client.PutAsync("https://localhost:44320/api/Product/", stringContent);

        if (updateResponse.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View(dto); // Hata durumunda aynı sayfayı yeniden yükleyin
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:44320/api/Product?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

}
