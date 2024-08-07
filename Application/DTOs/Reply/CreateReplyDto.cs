using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reply
{
    public class CreateReplyDto
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }
    }
}
