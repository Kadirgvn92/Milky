namespace Milky.WebUI.DTOs.Employee;

public class ResultEmployeeDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public string ImageUrl { get; set; }
    public IFormFile Image { get; set; }
}
