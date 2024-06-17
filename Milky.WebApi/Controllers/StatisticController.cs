using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatisticController : ControllerBase
{
    private readonly IStatisticService _StatisticService;

    public StatisticController(IStatisticService StatisticService)
    {
        _StatisticService = StatisticService;
    }
    [HttpGet]
    public IActionResult GetStatistic()
    {
        var values = _StatisticService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateStatistic(Statistic Statistic)
    {
        _StatisticService.TCreate(Statistic);
        return Ok("İstatistik başarıyla eklendi");
    }
    [HttpDelete]
    public IActionResult DeleteStatistic(int id)
    {
        _StatisticService.TDelete(id);
        return Ok("İstatistik başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateStatistic(Statistic Statistic)
    {
        _StatisticService.TUpdate(Statistic);
        return Ok("İstatistik başarılı şekilde güncellendi");
    }
    [HttpGet("GetStatisticById")]
    public IActionResult GetStatisticById(int id)
    {
        var values = _StatisticService.TGetByID(id);
        return Ok(values);
    }
}
