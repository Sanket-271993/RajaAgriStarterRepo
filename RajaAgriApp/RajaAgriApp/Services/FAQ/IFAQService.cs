using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IFAQService
    {
        Task<FAQResponseModel> GetFAQ(int FAQCategoryId);
    }
}
