﻿using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete;
public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void TCreate(Contact entity)
    {
        _contactDal.Create(entity);
    }

    public void TDelete(int id)
    {
     _contactDal.Delete(id);
    }

    public List<Contact> TGetAll()
    {
       return _contactDal.GetAll();
    }

    public Contact TGetByID(int id)
    {
       return _contactDal.GetByID(id);
    }

    public void TUpdate(Contact entity)
    {
      _contactDal.Update(entity);
    }
}
