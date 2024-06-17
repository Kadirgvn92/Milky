using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SocialMediaController : ControllerBase
{
    private readonly ISocialMediaService _SocialMediaService;
    public SocialMediaController(ISocialMediaService SocialMediaService)
    {
        _SocialMediaService = SocialMediaService;
    }
    [HttpGet]
    public IActionResult GetSocialMedia()
    {
        var values = _SocialMediaService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateSocialMedia(SocialMedia SocialMedia)
    {
        _SocialMediaService.TCreate(SocialMedia);
        return Ok("Sosyal Medya başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteSocialMedia(int id)
    {
        _SocialMediaService.TDelete(id);
        return Ok("Sosyal Medya başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateSocialMedia(SocialMedia SocialMedia)
    {
        _SocialMediaService.TUpdate(SocialMedia);
        return Ok("Sosyal Medya başarılı şekilde güncellendi");
    }
    [HttpGet("GetSocialMediaById")]
    public IActionResult GetSocialMediaById(int id)
    {
        var values = _SocialMediaService.TGetByID(id);
        return Ok(values);
    }
}
