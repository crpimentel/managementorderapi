using managementorderapi.Data;
using managementorderapi.Models;
using managementorderapi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace managementorderapi.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        // This no a good practice have context of db in repository i make to include property 
        private readonly AppDbContext _context;

        public ClientService(IRepository<Client> clientRepository, AppDbContext context)
        {
            _context = context;
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> getAllClientsWithOrdersAndProducts()
        {
            try
            {
                
                return await _context.Clients
                     .Include(client => client.Orders)
                         .ThenInclude(order => order.OrderProducts)
                             .ThenInclude(orderProduct => orderProduct.Product)
                     .Include(client => client.Orders)
                         .ThenInclude(order => order.OrderStatus)
                     .Include(client => client.Orders)  // Fixing the navigation context
                         .ThenInclude(order => order.Supplier)  // Including the Supplier for each Order
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception if a logging system is in place
                // Example: _logger.LogError(ex, "Error fetching clients with orders and products");
                throw new ApplicationException("A ocurrido un error buscando las ordenes de un cliente.");
            }
        }



        public async Task<IEnumerable<Client>> GetAll(params Expression<Func<Client, object>>[] includes)
        {
            var clients = await _clientRepository.GetAll();
            return clients;
        }

        public Task<Client> GetById(int id, params Expression<Func<Client, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
