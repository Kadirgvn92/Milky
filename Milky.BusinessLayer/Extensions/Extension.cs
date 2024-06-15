using Microsoft.Extensions.DependencyInjection;
using Milky.BusinessLayer.Abstract;
using Milky.BusinessLayer.Concrete;
using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Extensions;
public static class Extension
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<ICategoryService, CateogoryManager>();

        services.AddScoped<ISliderDal, EfSliderDal>();
        services.AddScoped<ISliderService, SliderManager>();

        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<IProductService, ProductManager>();
    }
}
