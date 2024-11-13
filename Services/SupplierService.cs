using managementorderapi.Models;
using managementorderapi.Repositories;
using System.Linq.Expressions;

namespace managementorderapi.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _supplierrepository;

        public SupplierService(IRepository<Supplier> repository)
        {
            _supplierrepository = repository;
        }
        public Task Add(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Supplier>> GetAll(params Expression<Func<Supplier, object>>[] includes)
        {
            var supliers = await _supplierrepository.GetAll();
            return supliers;
        }

        public Task<Supplier> GetById(int id, params Expression<Func<Supplier, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
