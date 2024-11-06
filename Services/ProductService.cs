using managementorderapi.Models;
using managementorderapi.Repositories;
using System;

namespace managementorderapi.Services
{
    public class ProductService : IRepositoryProduct
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public Task Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> FilterProductsAsync(int? id, string name, int? stock, decimal? price, string description)
        {
            // Obtener todos los productos
            var products = await _repository.GetAll();

            // Aplicar filtros según los parámetros que no sean null o vacíos
            if (id.HasValue)
            {
                products = products.Where(p => p.Id == id.Value);
            }
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name));
            }
            if (stock.HasValue)
            {
                products = products.Where(p => p.Stock == stock.Value);
            }
            if (price.HasValue)
            {
                products = products.Where(p => p.Price == price.Value);
            }
            if (!string.IsNullOrEmpty(description))
            {
                products = products.Where(p => p.Description.Contains(description));
            }

            return products;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _repository.GetAll();
            return products;
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
