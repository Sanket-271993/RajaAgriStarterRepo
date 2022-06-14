using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IOrderHistoryController
    {
        Task<OrderHistoryResponseModel> GetOrderHistory();
    }
}
