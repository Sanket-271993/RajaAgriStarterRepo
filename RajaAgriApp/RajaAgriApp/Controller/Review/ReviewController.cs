using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IReviewController
    {
        Task<ReviewResponseModel> PostSubmitProductRating(ReviewRequestModel reviewRequest);
    }
    public class ReviewController : IReviewController
    {
        private IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public Task<ReviewResponseModel> PostSubmitProductRating(ReviewRequestModel reviewRequest)
        {
            var response= _reviewService.PostSubmitProductRating(reviewRequest);
            return response;
        }
    }
}
