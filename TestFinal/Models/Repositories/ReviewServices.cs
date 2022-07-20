using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFinal.DAL.Interfaces;
using TestFinal.Data;

namespace TestFinal.Models.Repositories
{
    public class ReviewServices:IReviewServices
    {
		private readonly IGenericRepository<Review> reviewRepo;
		private readonly MyDbContext dBContext;

		public ReviewServices(IGenericRepository<Review> _reviewRepo, MyDbContext _dBContext)
		{
			reviewRepo = _reviewRepo;
			dBContext = _dBContext;
		}

		public async Task AddReviewAsync(Review review)
		{
			await reviewRepo.Insert(review);
		}


		public async Task DeleteReviewAsync(Review review)
		{
			await reviewRepo.Delete(review);
		}
	
		public async Task<Review> GetReviewByIdAsync(int id)
		{
			return await reviewRepo.GetById(id);
		}

		public IEnumerable<Review> ListAllReview()
		{
			return reviewRepo.GetAll();
		}

		public async Task UpdateReviewAsync(Review review)
		{
			await reviewRepo.Update(review);
		}

		public List<Review> GetAllGroupClass()
		{
			var reviews = reviewRepo.GetAll().ToList();
			return reviews;
		}
	}
}
