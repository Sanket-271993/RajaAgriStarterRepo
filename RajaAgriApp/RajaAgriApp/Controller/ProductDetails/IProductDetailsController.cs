using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IProductDetailsController
    {
        Task<ProductDetailsResponseModel> GetProductDetails(ProductDetailsRequestModel requestModel);
    }
}
