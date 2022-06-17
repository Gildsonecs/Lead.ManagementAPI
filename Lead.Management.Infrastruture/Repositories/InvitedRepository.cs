using Dapper;
using Lead.Management.Domain.Entities;
using Lead.Management.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lead.Management.Infrastruture.Repositories
{
    public class InvitedRepository : DapperRepository, IInvitedRepository
    {
        public InvitedRepository(IConfiguration config) 
            : base(config.GetConnectionString(Config.SqlServer.ConnectionString))
        {
        }

        public async Task<IEnumerable<Contacts>> GetAllAsync() 
        {
            var query = Scripts.ContactScripts.LIST_CONTACTS;

            using var connection = Connection;

            return await connection.QueryAsync<Contacts>(query);
        }

        public async Task<Contacts> GetByIdAsync(Guid id)  
        {
            var query = Scripts.ContactScripts.CONTACT_OBTER;

            using var connection = Connection;

            return await connection.QueryFirstOrDefaultAsync<Contacts>(query, new { Id = id });
        }

        public async Task<IEnumerable<Contacts>> GetAllAcceptAsync()  
        {
            var query = Scripts.ContactScripts.CONTACT_ACCEPT;

            using var connection = Connection;

            return await connection.QueryAsync<Contacts>(query, new { Accept = true });
        }

        public async Task AddAsync(Contacts entity)
        {
            var query = Scripts.ContactScripts.CONTACT_ADD;

            using var connection = Connection;

            await connection.ExecuteAsync(query, entity);
        }

        public async Task ChangeAcceptAsync(Contacts entity)  
        {
            var query = Scripts.ContactScripts.UPDATE_CONTACT_ACCEPT;

            using var connection = Connection;

            await connection.ExecuteAsync(query, new { entity.Id });
        }

        public async Task ChangeDeclineAsync(Guid id)
        {
            var query = Scripts.ContactScripts.UPDATE_CONTACT_DECLINE;

            using var connection = Connection;

            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
