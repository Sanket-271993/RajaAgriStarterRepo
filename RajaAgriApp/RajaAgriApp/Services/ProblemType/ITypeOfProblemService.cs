using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface ITypeOfProblemService
    {
        Task<TypeOfProblemResponseModel> GetTypeOfProblem();
    }
}
