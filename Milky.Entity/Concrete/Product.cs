using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class Product : BaseEntity
{
    public string? ProductName { get; set; }
    public decimal NewPrice { get; set; }
    public decimal OldPrice { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
}
