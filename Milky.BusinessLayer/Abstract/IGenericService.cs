using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Abstract;
public interface IGenericService<T> where T : class
{
    void TCreate(T entity);
    void TUpdate(T entity);
    void TDelete(int id);
    List<T> TGetAll();
    T TGetByID(int id);
}
