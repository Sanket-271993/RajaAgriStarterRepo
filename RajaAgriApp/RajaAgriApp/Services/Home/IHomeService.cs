using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IHomeService
    {
        Task<ProductResponseModel> GetHome();
    }
}
