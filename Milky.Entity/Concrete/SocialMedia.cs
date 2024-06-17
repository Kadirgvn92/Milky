using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class SocialMedia : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }
    public int Type { get; set; }
    public List<Employee> Employees { get; set; }
}
