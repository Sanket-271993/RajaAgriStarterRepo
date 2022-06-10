using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IDealerController
    {
        Task<DealerResponseModel> GetDealer();
    }
}
