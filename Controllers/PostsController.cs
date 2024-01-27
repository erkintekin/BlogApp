using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
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
        private readonly ICommentRepository _commentRepository;

        public PostsController(IPostRepository postRepository, ITagRepository tagRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _commentRepository = commentRepository;

        }

        public IActionResult Index(string tag)
        {
            var claims = User.Claims;
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
            return View(await _postRepository
            .Posts.Include(x => x.Tags).Include(x => x.Comments).ThenInclude(x => x.User)
            .FirstOrDefaultAsync(p => p.Url == url));
        }
        [HttpPost]
        public JsonResult AddComment(int PostId, string UserName, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);  // Username için Claimtype methodu
            var avatar = User.FindFirstValue(ClaimTypes.UserData); // Kullanıcı verileri için img vb.
            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComment(entity);
            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });
        }
    }
}