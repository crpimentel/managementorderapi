using System.Linq.Expressions;

namespace managementorderapi.Repositories
{
    //Interfaz generica para crear operaciones Crud de manera generica
    //public interface IRepository<T> where T : class
    //{
    //    Task<IEnumerable<T>> GetAll();
    //    Task<T> GetById(int id);
    //    Task Add(T entity);
    //    Task Update(T entity);
    //    Task Delete(int id);
    //    Task Save();
    //}

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includes);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task Save();
    }

}
