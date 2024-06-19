namespace Milky.WebUI.DTOs.Slider;

public class UpdateSliderDto
{
    public int ID { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? Image { get; set; }
    public string? Description1 { get; set; }
    public string? Description2 { get; set; }
}
