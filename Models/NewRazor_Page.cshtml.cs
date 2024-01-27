using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlogApp.Models
{
    public class NewRazor_Page : PageModel
    {
        private readonly ILogger<NewRazor_Page> _logger;

        public NewRazor_Page(ILogger<NewRazor_Page> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}