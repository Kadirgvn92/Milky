using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class SliderManager : ISliderService
{
    private readonly ISliderDal _sliderDal;

    public SliderManager(ISliderDal sliderDal)
    {
        _sliderDal = sliderDal;
    }

    public void TCreate(Slider entity)
    {
        _sliderDal.Create(entity);
    }

    public void TDelete(int id)
    {
       _sliderDal.Delete(id);
    }

    public List<Slider> TGetAll()
    {
        return _sliderDal.GetAll(); 
    }

    public Slider TGetByID(int id)
    {
      return _sliderDal.GetByID(id);
    }

    public void TUpdate(Slider entity)
    {
      _sliderDal.Update(entity);
    }
}
