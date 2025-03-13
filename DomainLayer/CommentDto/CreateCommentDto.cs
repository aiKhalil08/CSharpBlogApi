using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CommentDto
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public int PostId { get; set; }    
        public string UserId { get; set; }   
    }
}
