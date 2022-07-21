using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IFAQCategoryService
    {
        Task<FAQCategoryResponseModel> GetFAQCategory();
    }
}
