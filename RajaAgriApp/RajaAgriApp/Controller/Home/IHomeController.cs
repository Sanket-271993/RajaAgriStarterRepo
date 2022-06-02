using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IHomeController
    {
        Task<ProductResponseModel> GetHome();
    }
}
