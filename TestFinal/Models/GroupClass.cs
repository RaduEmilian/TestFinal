using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.Models
{
    public class GroupClass
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String RoomNumber { get; set; }
        public int ReviewId { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
