using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly ITestimonialService _TestimonialService;

    public TestimonialController(ITestimonialService TestimonialService)
    {
        _TestimonialService = TestimonialService;
    }
    [HttpGet]
    public IActionResult GetTestimonial()
    {
        var values = _TestimonialService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateTestimonial(Testimonial Testimonial)
    {
        _TestimonialService.TCreate(Testimonial);
        return Ok("Yorum başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteTestimonial(int id)
    {
        _TestimonialService.TDelete(id);
        return Ok("Yorum başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateTestimonial(Testimonial Testimonial)
    {
        _TestimonialService.TUpdate(Testimonial);
        return Ok("Yorum başarılı şekilde güncellendi");
    }
    [HttpGet("GetTestimonialById")]
    public IActionResult GetTestimonialById(int id)
    {
        var values = _TestimonialService.TGetByID(id);
        return Ok(values);
    }
}
