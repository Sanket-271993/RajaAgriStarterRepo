using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IDealerService
    {
         Task<DealerResponseModel> GetDealer();
    }
}
