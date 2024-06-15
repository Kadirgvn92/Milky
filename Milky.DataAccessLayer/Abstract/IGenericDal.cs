﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.Abstract;
public interface IGenericDal<T> where T : class
{
    void Create (T entity); 
    void Update (T entity);
    void Delete (int id);
    List<T> GetAll ();
    T GetByID (int id);
}
