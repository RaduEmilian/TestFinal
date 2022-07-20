using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.ViewModels
{
    public class CreateReviewViewModel
    {
        public int ReviewId { get; set; }
        public string ReviewMessage { get; set; }

        public int UserId { get; set; }
    }
}
