using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IFAQController
    {
        Task<FAQResponseModel> GetFAQ(int FAQCategoryId);
        Task<FAQCategoryResponseModel> GetFAQCategory();
    }
}
