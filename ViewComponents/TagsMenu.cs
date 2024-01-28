using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.ViewComponents
{
    public class TagsMenu : ViewComponent   // Zorunlu !  Invoke methodunu unutma. Controller gibi davranır.
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagsMenu(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _tagRepository.List.ToListAsync());
        }
    }
}