using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IServicesService _ServicesService;

    public ServicesController(IServicesService ServicesService)
    {
        _ServicesService = ServicesService;
    }
    [HttpGet]
    public IActionResult GetServices()
    {
        var values = _ServicesService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateServices(Services Services)
    {
        _ServicesService.TCreate(Services);
        return Ok("Hizmetler başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteServices(int id)
    {
        _ServicesService.TDelete(id);
        return Ok("Hizmetler başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateServices(Services Services)
    {
        _ServicesService.TUpdate(Services);
        return Ok("Hizmetler başarılı şekilde güncellendi");
    }
    [HttpGet("GetServicesById")]
    public IActionResult GetServicesById(int id)
    {
        var values = _ServicesService.TGetByID(id);
        return Ok(values);
    }
}
