using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using SQLitePCL;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfUserRepository : IUserRepository
    {
        private readonly BlogContext _context;

        public EfUserRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users; // => ten sonrası get; kısmı. Filtreleme buradan yapılır.

        // _context.Users bize BlogContext'e ait Users tablosu listesindeki verileri gösterir. IQueryable<User> Users ise Dışarıdan bu listeyi çağırmak istediğimizde ve üzerinde sorgulama, listeleme yapmak istediğimizde kullanıyoruz.

        public void CreateUser(User User)
        {

            _context.Users.Add(User);
            _context.SaveChanges();
        }
    }
}