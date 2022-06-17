using Lead.Management.Application.Models;
using System.Threading.Tasks;

namespace Lead.Management.Application.Interfaces
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(string recipientEmail, float discountedValue);
    }
}
