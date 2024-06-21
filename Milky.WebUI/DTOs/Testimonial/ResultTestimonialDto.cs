namespace Milky.WebUI.DTOs.Testimonial;

public class ResultTestimonialDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public IFormFile Image { get; set; }
}
