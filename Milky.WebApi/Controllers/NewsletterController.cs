using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NewsletterController : ControllerBase
{
    private readonly INewsletterService _NewsletterService;

    public NewsletterController(INewsletterService NewsletterService)
    {
        _NewsletterService = NewsletterService;
    }
    [HttpGet]
    public IActionResult GetNewsletter()
    {
        var values = _NewsletterService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateNewsletter(Newsletter Newsletter)
    {
        _NewsletterService.TCreate(Newsletter);
        return Ok("Abonelik başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteNewsletter(int id)
    {
        _NewsletterService.TDelete(id);
        return Ok("Abonelik başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateNewsletter(Newsletter Newsletter)
    {
        _NewsletterService.TUpdate(Newsletter);
        return Ok("Abonelik başarılı şekilde güncellendi");
    }
    [HttpGet("GetNewsletterById")]
    public IActionResult GetNewsletterById(int id)
    {
        var values = _NewsletterService.TGetByID(id);
        return Ok(values);
    }
}
