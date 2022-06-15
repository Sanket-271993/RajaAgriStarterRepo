using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IProfileController
    {
        Task<ProfileResponseModel> GetProfile();
        Task<ProfileImageResponseModel> PostProfileImageUpdate(ProfileImageRequstModel profileImageRequstModel);
    }
}
