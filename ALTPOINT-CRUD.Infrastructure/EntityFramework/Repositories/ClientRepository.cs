using Microsoft.EntityFrameworkCore;

using ALTPOINT_CRUD.Domain.Contracts;
using ALTPOINT_CRUD.Domain.Entities;
using ALTPOINT_CRUD.Infrastructure.EntityFramework.Contexts;

namespace ALTPOINT_CRUD.Infrastructure.EntityFramework.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataBaseContext _dbContext;
        public ClientRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client> Create(Client client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetBy(Guid id) =>
            await _dbContext.Clients.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<Client> Update(Client client)
        {
            await _dbContext.SaveChangesAsync();
            return client;
        }
    }
}
