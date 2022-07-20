using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.Models
{
    public class GalleryIndexModel
    {
        public virtual IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
