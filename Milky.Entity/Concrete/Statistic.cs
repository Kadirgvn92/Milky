using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class Statistic : BaseEntity
{
    public int Count { get; set; }
    public string Name { get; set; }
}
