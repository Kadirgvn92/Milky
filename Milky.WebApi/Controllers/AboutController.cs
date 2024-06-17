using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _AboutService;

    public AboutController(IAboutService AboutService)
    {
        _AboutService = AboutService;
    }
    [HttpGet]
    public IActionResult GetAbout()
    {
        var values = _AboutService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateAbout(About About)
    {
        _AboutService.TCreate(About);
        return Ok("Hakkımızda başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteAbout(int id)
    {
        _AboutService.TDelete(id);
        return Ok("Hakkımızda başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateAbout(About About)
    {
        _AboutService.TUpdate(About);
        return Ok("Hakkımızda başarılı şekilde güncellendi");
    }
    [HttpGet("GetAboutById")]
    public IActionResult GetAboutById(int id)
    {
        var values = _AboutService.TGetByID(id);
        return Ok(values);
    }
}
