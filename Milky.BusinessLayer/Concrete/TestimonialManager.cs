
using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _dal;

    public TestimonialManager(ITestimonialDal dal)
    {
        _dal = dal;
    }

    public void TCreate(Testimonial entity)
    {
      _dal.Create(entity);
    }

    public void TDelete(int id)
    {
       _dal.Delete(id);
    }

    public List<Testimonial> TGetAll()
    {
        return _dal.GetAll();
    }

    public Testimonial TGetByID(int id)
    {
        return _dal.GetByID(id);
    }

    public void TUpdate(Testimonial entity)
    {
       _dal.Update(entity);
    }
}
