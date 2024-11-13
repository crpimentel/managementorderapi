using managementorderapi.Models;

namespace managementorderapi.Repositories
{
    public interface IRepositoryProduct:IRepository<Product>
    {
        Task<IEnumerable<Product>> FilterProductsAsync(int? id, string name, int? stock, decimal? price, string description);
        Task<IEnumerable<Product>> GetAllWithoutImages();
    }
}
