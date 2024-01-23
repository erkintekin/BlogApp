using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{



    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;

        public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;

        }

        public IActionResult Index(string tag)
        {
            var posts = _postRepository.Posts; // IEnumerable şeklinde.

            if (!String.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag)); // Any olanları getir demek.

                return View(posts.ToList());
            }
            else
            {

                return View(posts.ToList());

                //      return View(new PostViewModel
                // {
                //     Posts = _postRepository.Posts.ToList(),
                //     // Tags = _tagRepository.Tags.ToList()
                // });
            }


        }

        public async Task<IActionResult> Details(string? url)
        {
            return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.Url == url));
        }

    }
}