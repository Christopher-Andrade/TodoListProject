using System.Threading.Tasks;

namespace SportsEvents.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
