using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class StatisticManager : IStatisticService
{
    private readonly IStatisticDal _statisticDal;

    public StatisticManager(IStatisticDal statisticDal)
    {
        _statisticDal = statisticDal;
    }

    public void TCreate(Statistic entity)
    {
        _statisticDal.Create(entity);
    }

    public void TDelete(int id)
    {
        _statisticDal.Delete(id);
    }

    public List<Statistic> TGetAll()
    {
        return _statisticDal.GetAll();
    }

    public Statistic TGetByID(int id)
    {
        return _statisticDal.GetByID(id);
    }

    public void TUpdate(Statistic entity)
    {
        _statisticDal.Update(entity);
    }
}
