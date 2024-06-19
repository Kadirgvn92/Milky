using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NewsletterController : ControllerBase
{
    private readonly INewsletterService _newsletterService;

    public NewsletterController(INewsletterService newsletterService)
    {
        _newsletterService = newsletterService;
    }
    [HttpGet]
    public IActionResult GetNewsletter()
    {
        var values = _newsletterService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateNewsletter(Newsletter Newsletter)
    {
        _newsletterService.TCreate(Newsletter);
        return Ok("Abonelik başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteNewsletter(int id)
    {
        _newsletterService.TDelete(id);
        return Ok("Abonelik başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateNewsletter(Newsletter Newsletter)
    {
        _newsletterService.TUpdate(Newsletter);
        return Ok("Abonelik başarılı şekilde güncellendi");
    }
    [HttpGet("GetNewsletterById")]
    public IActionResult GetNewsletterById(int id)
    {
        var values = _newsletterService.TGetByID(id);
        return Ok(values);
    }
}
