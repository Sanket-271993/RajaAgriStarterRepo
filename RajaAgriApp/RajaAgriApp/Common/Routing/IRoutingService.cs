using System.Threading.Tasks;

namespace NavistarOCCApp.Common
{
    public interface IRoutingService
    {
        Task GoBack();
        Task GoBackModal();
        Task NavigateTo(string route);
    }
}
