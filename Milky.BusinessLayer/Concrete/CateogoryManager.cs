using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class CateogoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CateogoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void TCreate(Category entity)
    {
        _categoryDal.Create(entity);
    }

    public void TDelete(int id)
    {
        _categoryDal.Delete(id);
    }

    public List<Category> TGetAll()
    {
        return _categoryDal.GetAll();
    }

    public Category TGetByID(int id)
    {
        return _categoryDal.GetByID(id);
    }

    public void TUpdate(Category entity)
    {
        _categoryDal.Update(entity);
    }
}
