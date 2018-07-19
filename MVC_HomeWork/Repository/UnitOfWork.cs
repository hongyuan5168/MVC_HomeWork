using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using  MVC_HomeWork.Models;

namespace MVC_HomeWork.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public UnitOfWork()
        {
            Context = new Model1();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}