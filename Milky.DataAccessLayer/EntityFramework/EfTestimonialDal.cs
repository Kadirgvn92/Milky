using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Context;
using Milky.DataAccessLayer.Repositories;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.EntityFramework;
public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
{
    public EfTestimonialDal(MilkyContext context) : base(context)
    {
    }
}
