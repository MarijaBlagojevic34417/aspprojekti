using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.RateAp
{
    public class RateDto
    {
        public int Id { get; set; }
        public int NameRate { get; set; }
      
    }
    public class CreateRateDto
    {
        public int NameRate { get; set; }
       
    }
    public class UpdateRateDto
    {
        public int Id { get; set; }
        public int NameRate { get; set; }
       
    }

    public class DeleteRateDto
    {
        public int Id { get; set; }
    }
}
