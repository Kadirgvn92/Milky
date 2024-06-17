using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _ContactService;

    public ContactController(IContactService ContactService)
    {
        _ContactService = ContactService;
    }
    [HttpGet]
    public IActionResult GetContact()
    {
        var values = _ContactService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateContact(Contact Contact)
    {
        _ContactService.TCreate(Contact);
        return Ok("İletişim bilgileri başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteContact(int id)
    {
        _ContactService.TDelete(id);
        return Ok("İletişim bilgileri başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateContact(Contact Contact)
    {
        _ContactService.TUpdate(Contact);
        return Ok("İletişim bilgileri başarılı şekilde güncellendi");
    }
    [HttpGet("GetContactById")]
    public IActionResult GetContactById(int id)
    {
        var values = _ContactService.TGetByID(id);
        return Ok(values);
    }
}
