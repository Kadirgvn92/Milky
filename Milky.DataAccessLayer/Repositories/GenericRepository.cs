using Microsoft.EntityFrameworkCore;
using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Context;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.Repositories;
public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
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
        var entity = _context.Set<T>().Find(id);
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        var values = _context.Set<T>().Where(e => e.IsDeleted == false).ToList();
        return values;
    }

    public T GetByID(int id)
    {
        var entity = _context.Set<T>().Find(id);
        return entity != null && !entity.IsDeleted ? entity : null;
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
