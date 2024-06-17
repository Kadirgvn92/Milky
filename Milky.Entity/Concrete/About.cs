using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class About : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Subtitle1 { get; set; }
    public string Subtitle2 { get; set; }
    public string ShortDescription1 { get; set; }
    public string ShortDescription2 { get; set; }
}
