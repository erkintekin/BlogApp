using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entity
{

    public enum TagColors
    {
        primary,
        danger,
        warning,
        success,
        info,
        secondary,
        dark
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string? Text { get; set; }
        public string? Url { get; set; }
        public TagColors Colors { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

    }
}