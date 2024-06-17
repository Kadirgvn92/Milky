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

        services.AddScoped<IAboutDal, EfAboutDal>();
        services.AddScoped<IAboutService, AboutManager>();

        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<IContactService, ContactManager>();

        services.AddScoped<IEmployeeDal, EfEmployeeDal>();
        services.AddScoped<IEmployeeService, EmployeeManager>();

        services.AddScoped<INewsletterDal, EfNewsletterDal>();
        services.AddScoped<INewsletterService, NewsletterManager>();

        services.AddScoped<IServiceDal, EfServicesDal>();
        services.AddScoped<IServicesService, ServicesManager>();

        services.AddScoped<IStatisticDal, EfStatisticDal>();
        services.AddScoped<IStatisticService, StatisticManager>();

        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
    }
}
