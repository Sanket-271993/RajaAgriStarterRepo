using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IProfileImageUpdateService
    {
        Task<ProfileImageResponseModel> PostProfileImageUpdate(ProfileImageRequstModel profileImageRequstModel);
    }
}
