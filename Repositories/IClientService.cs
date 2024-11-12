using managementorderapi.Models;

namespace managementorderapi.Repositories
{
    public interface IClientService:IRepository<Client>
    {
        Task<IEnumerable<Client>> getAllClientsWithOrdersAndProducts();
    }
}
