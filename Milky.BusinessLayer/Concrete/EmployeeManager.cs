using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class EmployeeManager : IEmployeeDal
{
    private readonly IEmployeeDal _employeeDal;

    public EmployeeManager(IEmployeeDal employeeDal)
    {
        _employeeDal = employeeDal;
    }

    public void Create(Employee entity)
    {
        _employeeDal.Create(entity);
    }

    public void Delete(int id)
    {
        _employeeDal.Delete(id);
    }

    public List<Employee> GetAll()
    {
        return _employeeDal.GetAll();
    }

    public Employee GetByID(int id)
    {
       return _employeeDal.GetByID(id);
    }

    public void Update(Employee entity)
    {
        _employeeDal.Update(entity);
    }
}
