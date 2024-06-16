using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.Context;
public class MilkyContext :DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-A6C5CRN\\MSSQLSERVER01;Initial Catalog = MilkyDb;Integrated Security=True;Trust Server Certificate=True;");
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Slider> Sliders { get; set; }
}
