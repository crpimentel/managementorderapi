using managementorderapi.Helper;
using managementorderapi.Models;
using managementorderapi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace managementorderapi.Services
{
    public class ProductService : IRepositoryProduct
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public Task Add(Product product)
        {
            
            _repository.Add(product);
            return _repository.Save();

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

       

        public async Task<IEnumerable<Product>> GetAll(params Expression<Func<Product, object>>[] includes)
        {
            // Fetch products with ProductImages included
            var products = await _repository.GetAll(p => p.ProductImages);
            return products;

        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id, params Expression<Func<Product, object>>[] includes)
        {
            // Fetch product by ID with ProductImages included
            return _repository.GetById(id, p => p.ProductImages);
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
