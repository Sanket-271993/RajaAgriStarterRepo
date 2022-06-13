using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IProductTypeService
    {
        Task<ProductTypeResponseModel> GetProductType();
    }
}
