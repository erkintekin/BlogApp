using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using SQLitePCL;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts; // => ten sonrası get; kısmı. Filtreleme buradan yapılır.

        // _context.Posts bize BlogContext'e ait Posts tablosu listesindeki verileri gösterir. IQueryable<Post> Posts ise Dışarıdan bu listeyi çağırmak istediğimizde ve üzerinde sorgulama, listeleme yapmak istediğimizde kullanıyoruz.

        public void CreatePost(Post Post)
        {

            _context.Posts.Add(Post);
            _context.SaveChanges();
        }
    }
}