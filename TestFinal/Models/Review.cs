using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewMessage { get; set; }
        public int Rate { get; set; }
        public DateTime ReviewDate { get; set; }
        public virtual GroupClass GroupClass { get; set; }
        public virtual ApplicationUser User { get; set; }
        
    }
}
