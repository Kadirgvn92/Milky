using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _EmployeeService;

    public EmployeeController(IEmployeeService EmployeeService)
    {
        _EmployeeService = EmployeeService;
    }
    [HttpGet]
    public IActionResult GetEmployee()
    {
        var values = _EmployeeService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateEmployee(Employee Employee)
    {
        _EmployeeService.TCreate(Employee);
        return Ok("Personel bilgileri başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteEmployee(int id)
    {
        _EmployeeService.TDelete(id);
        return Ok("Personel bilgileri başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateEmployee(Employee Employee)
    {
        _EmployeeService.TUpdate(Employee);
        return Ok("Personel bilgileri başarılı şekilde güncellendi");
    }
    [HttpGet("GetEmployeeById")]
    public IActionResult GetEmployeeById(int id)
    {
        var values = _EmployeeService.TGetByID(id);
        return Ok(values);
    }
}
