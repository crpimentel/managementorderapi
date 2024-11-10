using managementorderapi.Models;

namespace managementorderapi.Repositories
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> getAllClientsWithOrdersAndProducts();
    }
}
