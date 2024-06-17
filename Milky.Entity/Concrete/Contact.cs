using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class Contact : BaseEntity
{
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string OpeningHoursWeekdays { get; set; }
    public string OpeningHoursWeekends { get; set; }
    public string OpeningHoursSunday { get; set; }
}
