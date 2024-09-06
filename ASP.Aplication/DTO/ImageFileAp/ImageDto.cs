using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.Image
{
    public class ImageFileDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }

    public class CreateImageFileDto
    {
        public string Path { get; set; }
       
    }
    public class UpdateImageFileDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
       
    }

    public class DeleteImageFileDto
    {
        public int Id { get; set; }
    }


}
