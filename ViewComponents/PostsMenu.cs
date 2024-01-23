using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class PostsMenu : ViewComponent
    {
        private readonly IPostRepository _postrepository;

        public PostsMenu(IPostRepository postrepository)
        {
            _postrepository = postrepository;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _postrepository.Posts.OrderByDescending(x => x.PublishedOn).Take(5).ToListAsync());
        }
    }
}