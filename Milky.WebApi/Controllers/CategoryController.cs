using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DTO.CategoryDtos;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public IActionResult GetCategory()
    {
        var values = _categoryService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        _categoryService.TCreate(category);
        return Ok("Kategori başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteCategory(int id)
    {
        _categoryService.TDelete(id);
        return Ok("Kategori başarıyla silindi");
    }
    [HttpPut]
    public IActionResult PutCategory(Category category)
    {
        _categoryService.TUpdate(category);
        return Ok("Kategori başarılı şekilde güncellendi");
    }
    [HttpGet("GetCategoryById")]
    public IActionResult GetCategoryById(int id)
    {
        var values = _categoryService.TGetByID(id);
        return Ok(values);
    }
}
