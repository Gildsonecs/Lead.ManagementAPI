using Lead.Management.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Lead.Management.Application.Interfaces
{
    public interface IInvitedApplication
    {
        Task CreateInvited(InviteCreateModel model);
        Task ChangeAccept(InvitedModel model);
        Task ChangeDecline(Guid id);

    }
}
