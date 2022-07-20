using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.Models.Repositories
{
   public interface IReviewServices
    {
		public Task AddReviewAsync(Review review);
		public Task DeleteReviewAsync(Review review);
		public Task UpdateReviewAsync(Review review);
		public IEnumerable<Review> ListAllReview();
		public Task<Review> GetReviewByIdAsync(int id);
		public List<Review> GetAllGroupClass();
	}
}
