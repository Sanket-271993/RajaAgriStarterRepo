using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IOrderHistoryService
    {
        Task<OrderHistoryResponseModel> GetOrderHistory();
    }
}
