namespace Application.Contracts.Base
{
    public interface IRepositoryBase<Tkey, T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Tkey id);

        Task<T> AddAsync(T obj);

        Task UpdateAsync(T obj);

        Task RemoveAsync(T obj);

        Task<bool> Exists(Tkey id);

        Task SaveChangesAsync();
    }
}
