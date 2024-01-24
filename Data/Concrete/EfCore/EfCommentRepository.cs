using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using SQLitePCL;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfCommentRepository : ICommentRepository
    {
        private readonly BlogContext _context;

        public EfCommentRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments; // => ten sonrası get; kısmı. Filtreleme buradan yapılır.

        // _context.Posts bize BlogContext'e ait Posts tablosu listesindeki verileri gösterir. IQueryable<Post> Posts ise Dışarıdan bu listeyi çağırmak istediğimizde ve üzerinde sorgulama, listeleme yapmak istediğimizde kullanıyoruz.

        public void CreateComment(Comment comment)
        {

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}