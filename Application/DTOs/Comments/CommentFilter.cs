using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Comments
{
    public class CommentFilter
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
