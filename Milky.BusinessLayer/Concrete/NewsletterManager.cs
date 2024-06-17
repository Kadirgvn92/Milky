using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class NewsletterManager : INewsletterService
{
    private readonly INewsletterDal _newsletterDal;

    public NewsletterManager(INewsletterDal newsletterDal)
    {
        _newsletterDal = newsletterDal;
    }

    public void TCreate(Newsletter entity)
    {
        _newsletterDal.Create(entity);
    }

    public void TDelete(int id)
    {
        _newsletterDal.Delete(id);
    }

    public List<Newsletter> TGetAll()
    {
        return _newsletterDal.GetAll();
    }

    public Newsletter TGetByID(int id)
    {
        return _newsletterDal.GetByID(id);
    }

    public void TUpdate(Newsletter entity)
    {
        _newsletterDal.Update(entity);
    }
}
