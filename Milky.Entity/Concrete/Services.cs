﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete;
public class Services : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string BackgroundImageUrl { get; set; }
}
