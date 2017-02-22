using System.Threading.Tasks;

namespace SportsEvents.Web.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
