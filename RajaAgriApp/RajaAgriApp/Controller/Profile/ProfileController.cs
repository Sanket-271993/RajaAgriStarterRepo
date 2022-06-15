using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public class ProfileController : IProfileController
    {
        private IProfileService _profileService;
        private IProfileImageUpdateService _profileImageUpdateService;
        public ProfileController(IProfileService profileService, IProfileImageUpdateService profileImageUpdateService)
        {
            _profileService = profileService;
            _profileImageUpdateService = profileImageUpdateService;
        }
        
        public async Task<ProfileResponseModel> GetProfile()
        {
            var response = await _profileService.GetProfile();
            return response;
        }

        public async Task<ProfileImageResponseModel> PostProfileImageUpdate(ProfileImageRequstModel profileImageRequstModel)
        {
            var response = await _profileImageUpdateService.PostProfileImageUpdate(profileImageRequstModel);
            return response;
        }
    }
}
