using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IProfileService
    {
        Task<ProfileResponseModel> GetProfile();
    }
}
