using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.Models
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DataType Created { get; set; }
        public string Url { get; set; }
        public virtual IEnumerable<ImageTag> Tags { get; set; }
    }
}
