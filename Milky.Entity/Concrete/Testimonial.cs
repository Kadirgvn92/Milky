﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class Testimonial : BaseEntity
{
    public string Name { get; set; }
    public string Job { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
}
