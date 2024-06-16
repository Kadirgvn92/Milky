using Milky.WebUI.DTOs.Product;

namespace Milky.WebUI.Areas.Admin.Models;

public class ProductViewModel
{
    public  List<ResultProductDto> Products { get; set; }
    public int TotalArticles { get; set; }
    public PageInfoModel PageInfo { get; set; }
}
