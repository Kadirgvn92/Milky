using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SliderController : ControllerBase
{
    private readonly ISliderService _SliderService;
    public SliderController(ISliderService SliderService)
    {
        _SliderService = SliderService;
    }
    [HttpGet]
    public IActionResult GetSlider()
    {
        var values = _SliderService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateSlider(Slider Slider)
    {
        _SliderService.TCreate(Slider);
        return Ok("Slider başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteSlider(int id)
    {
        _SliderService.TDelete(id);
        return Ok("Slider başarıyla silindi");
    }
    [HttpPut]
    public IActionResult PutSlider(Slider Slider)
    {
        _SliderService.TUpdate(Slider);
        return Ok("Slider başarılı şekilde güncellendi");
    }
    [HttpGet("GetSliderById")]
    public IActionResult GetSliderById(int id)
    {
        var values = _SliderService.TGetByID(id);
        return Ok(values);
    }
}
