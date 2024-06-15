using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void TCreate(Product entity)
    {
        _productDal.Create(entity);
    }

    public void TDelete(int id)
    {
        _productDal.Delete(id);
    }

    public List<Product> TGetAll()
    {
        return _productDal.GetAll();
    }

    public Product TGetByID(int id)
    {
        return _productDal.GetByID(id);
    }

    public void TUpdate(Product entity)
    {
        _productDal.Update(entity);
    }
}
