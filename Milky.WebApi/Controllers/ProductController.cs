using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService ProductService)
    {
        _productService = ProductService;
    }
    [HttpGet]
    public IActionResult GetProduct()
    {
        var values = _productService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateProduct(Product Product)
    {
        _productService.TCreate(Product);
        return Ok("Ürün başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteProduct(int id)
    {
        _productService.TDelete(id);
        return Ok("Ürün başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateProduct(Product Product)
    {
        _productService.TUpdate(Product);
        return Ok("Ürün başarılı şekilde güncellendi");
    }
    [HttpGet("GetProductById")]
    public IActionResult GetProductById(int id)
    {
        var values = _productService.TGetByID(id);
        return Ok(values);
    }
}
