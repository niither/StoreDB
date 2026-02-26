using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Infrastructure.Repositories
{
    public class ReviewRepository
    {
        private AppDbContext context;

        public ReviewRepository(AppDbContext context)
        {
            this.context = context;
        }

        // CRUD operations
        public void CreateReview(Review review)
        {
            context.Reviews?.Add(review);
            context.SaveChanges();
        }

        public void UpdateReview(int id, Review updatedReview)
        {
            var review = context.Reviews.FirstOrDefault(r => r.Id == id);
            if (review != null)
            {
                review.Rating = updatedReview.Rating;
                review.Text = updatedReview.Text;
                context.SaveChanges();
            }
        }

        public void DeleteReview(int id)
        {
            var review = context.Reviews?.FirstOrDefault(r => r.Id == id);
            if (review != null)
            {
                context.Reviews?.Remove(review);
                context.SaveChanges();
            }
        }

        public Review? GetReviewById(int id)
        {
            var review = context.Reviews?.FirstOrDefault(r => r.Id == id);
            return review;
        }

        public List<Review> GetAllReviews()
        {
            return context.Reviews?.ToList() ?? new List<Review>();
        }
    }
}