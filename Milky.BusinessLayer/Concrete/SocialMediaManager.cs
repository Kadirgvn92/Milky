using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class SocialMediaManager : ISocialMediaService
{
    private readonly ISocialMediaDal _socialMediaDal;

    public SocialMediaManager(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }

    public void TCreate(SocialMedia entity)
    {
        _socialMediaDal.Create(entity);
    }

    public void TDelete(int id)
    {
        _socialMediaDal.Delete(id);
    }

    public List<SocialMedia> TGetAll()
    {
       return _socialMediaDal.GetAll();
    }

    public SocialMedia TGetByID(int id)
    {
        return _socialMediaDal.GetByID(id);
    }

    public void TUpdate(SocialMedia entity)
    {
       _socialMediaDal.Update(entity);
    }
}
