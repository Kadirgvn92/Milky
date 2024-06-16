using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milky.WebUI.Areas.Admin.Models;
using Milky.WebUI.DTOs.Product;
using Newtonsoft.Json;

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
}
