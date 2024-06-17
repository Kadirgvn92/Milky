using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class ServicesManager : IServicesService
{
    private readonly IServiceDal _dal;

    public ServicesManager(IServiceDal dal)
    {
        _dal = dal;
    }

    public void TCreate(Services entity)
    {
        _dal.Create(entity);
    }

    public void TDelete(int id)
    {
        _dal.Delete(id);
    }

    public List<Services> TGetAll()
    {
        return _dal.GetAll();
    }

    public Services TGetByID(int id)
    {
        return _dal.GetByID(id);
    }

    public void TUpdate(Services entity)
    {
        _dal.Update(entity);
    }
}
