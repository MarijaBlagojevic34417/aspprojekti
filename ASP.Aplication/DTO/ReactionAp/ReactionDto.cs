using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.ReactionAp
{
    public class ReactionDto
    {

        public int Id { get; set; }
        public string NameReaction { get; set; }

    }
    public class CreateReactionDto
    {
        public string NameReaction { get; set; }

    }
    public class UpdateReactionDto
    {
        public int Id { get; set; }
        public string NameReaction { get; set; }

    }

    public class DeleteReactionDto
    {
        public int Id { get; set; }
    }
}

