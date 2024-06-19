namespace Milky.WebUI.DTOs.Product;

public class CreateProductDto
{
    public int ID { get; set; }
    public string? ProductName { get; set; }
    public decimal NewPrice { get; set; }
    public decimal OldPrice { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? Image { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
}
