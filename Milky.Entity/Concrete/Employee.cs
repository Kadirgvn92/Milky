using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class Employee : BaseEntity
{
    public string Name { get; set; }
    public string Job { get; set; }
    public string ImageUrl { get; set; }
    public int SocialMediaID { get; set; }
    public SocialMedia SocialMedia { get; set; }
}
