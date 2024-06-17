using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class AboutManager : IAboutService
{
    private readonly IAboutDal _dal;

    public AboutManager(IAboutDal dal)
    {
        _dal = dal;
    }

    public void TCreate(About entity)
    {
        _dal.Create(entity);
    }

    public void TDelete(int id)
    {
        _dal.Delete(id);
    }

    public List<About> TGetAll()
    {
        return _dal.GetAll();   
    }

    public About TGetByID(int id)
    {
       return _dal.GetByID(id);
    }

    public void TUpdate(About entity)
    {
       _dal.Update(entity);
    }
}
