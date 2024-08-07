using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Posts
{
    public class PostsFilterDto
    {
        public int? PostId { get; set; }
        public string? Title { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }
    }
}
