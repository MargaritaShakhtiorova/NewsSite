using System.ComponentModel.DataAnnotations.Schema;
using Diploma_v1._1.Areas.Identity.Data;

namespace Diploma_v1._1.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime TimeOfCreating { get; set; }
               
        public byte[] ImageData { get; set; }

        public Author Autor { get; set; }
    }
}
