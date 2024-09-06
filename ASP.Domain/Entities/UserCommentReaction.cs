using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class UserCommentReaction
    {
      
        public int IdUser { get; set; }
        public int IdComment{ get; set; }
        public int IdReaction{ get; set; }

        public User User { get; set; }
        public Comment Comment { get; set; }
        public Reaction Reaction { get; set; }

       
    }
}
