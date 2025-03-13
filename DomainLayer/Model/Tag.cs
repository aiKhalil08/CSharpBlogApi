using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Tag : BaseModel
    {
        public Tag()
        {
            Posts = new HashSet<Post>();
        }

        public string Name { get; set; }
       
        public virtual ICollection<Post> Posts { get; set; }
    }
}
