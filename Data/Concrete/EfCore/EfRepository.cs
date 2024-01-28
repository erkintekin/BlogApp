using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using SQLitePCL;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly BlogContext _context;

        public EfRepository(BlogContext context)
        {
            _context = context;
        }

        // public IQueryable<Post> List => _context.Posts;

        IQueryable<T> IRepository<T>.List => _context.Set<T>().AsQueryable();


        // public void Create(Post p)
        // {
        //     _context.Posts.Add(p);
        //     _context.SaveChanges();
        // }

        public void Create(T p)
        {
            _context.Set<T>().Add(p);
            _context.SaveChanges();
        }
        //public IQueryable<Post> Posts => _context.Posts; // => ten sonrası get; kısmı. Filtreleme buradan yapılır.

        // _context.Posts bize BlogContext'e ait Posts tablosu listesindeki verileri gösterir. IQueryable<Post> Posts ise Dışarıdan bu listeyi çağırmak istediğimizde ve üzerinde sorgulama, listeleme yapmak istediğimizde kullanıyoruz.

        // public void CreatePost(Post Post)
        // {

        //     _context.Posts.Add(Post);
        //     _context.SaveChanges();
        // }
    }
}