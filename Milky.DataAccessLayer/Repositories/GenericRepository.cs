using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.Repositories;
public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly MilkyContext _context;

    public GenericRepository(MilkyContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var values = _context.Set<T>().Find(id);
        _context.Set<T>().Remove(values); 
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        var values = _context.Set<T>().ToList();
        return values;
    }

    public T GetByID(int id)
    {
        var values = _context.Set<T>().Find(id);
        return values;
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
