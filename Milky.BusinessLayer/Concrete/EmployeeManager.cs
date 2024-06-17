using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeDal _employeeDal;

    public EmployeeManager(IEmployeeDal employeeDal)
    {
        _employeeDal = employeeDal;
    }

    public void TCreate(Employee entity)
    {
        _employeeDal.Create(entity);
    }

    public void TDelete(int id)
    {
        _employeeDal.Delete(id);
    }

    public List<Employee> TGetAll()
    {
        return _employeeDal.GetAll();
    }

    public Employee TGetByID(int id)
    {
       return _employeeDal.GetByID(id);
    }

    public void TUpdate(Employee entity)
    {
        _employeeDal.Update(entity);
    }
}
