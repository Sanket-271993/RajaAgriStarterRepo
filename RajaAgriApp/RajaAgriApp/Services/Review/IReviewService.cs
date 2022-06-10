using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IReviewService
    {
        Task<ReviewResponseModel> PostSubmitProductRating(ReviewRequestModel reviewRequest);
    }
}
