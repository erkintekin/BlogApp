using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> List { get; }
        void Create(T p);   // İmzalar bunlar
    }
}