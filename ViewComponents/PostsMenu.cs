using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class PostsMenu : ViewComponent
    {
        private readonly IRepository<Post> _postrepository;

        public PostsMenu(IRepository<Post> postrepository)
        {
            _postrepository = postrepository;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _postrepository.List.OrderByDescending(x => x.PublishedOn).Take(5).ToListAsync());
        }
    }
}