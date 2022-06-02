using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IProductDetailsService
    {
        Task<ProductDetailsResponseModel> GetProductDetails(ProductDetailsRequestModel requestModel);
    }
}
