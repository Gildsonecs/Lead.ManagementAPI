using Lead.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lead.Management.Domain.Repositories
{
    public interface IInvitedRepository
    {
        Task<IEnumerable<Contacts>> GetAllAsync();
        Task<Contacts> GetByIdAsync(Guid id);
        Task AddAsync(Contacts entity);
        Task ChangeAcceptAsync(Contacts entity);
        Task ChangeDeclineAsync(Guid id);
        Task<IEnumerable<Contacts>> GetAllAcceptAsync();
    }
}
