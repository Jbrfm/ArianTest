using Domain.DboContext;
using Application.Contracts.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base
{
    public class RepositoryBase<Tkey, T> : IRepositoryBase<Tkey, T> where T : class
    {
        private ArianTestContext _dboContext { get; set; }

        public RepositoryBase(ArianTestContext dbo)
        {
            _dboContext = dbo ?? throw new ArgumentNullException(nameof(RepositoryBase<Tkey, T>));
        }

        public async Task<T> AddAsync(T obj)
        {
            try
            {
                await _dboContext.AddAsync(obj);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var objects = await _dboContext.Set<T>().ToListAsync();

                return objects;
            }
            catch
            {
                throw new Exception();
            }

        }

        public async Task<T> GetAsync(Tkey id)
        {
            try
            {
                return await _dboContext.Set<T>().FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task RemoveAsync(T obj)
        {
            try
            {
                _dboContext.Set<T>().Remove(obj);
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task UpdateAsync(T obj)
        {
            try
            {
                _dboContext.Entry(obj).State = EntityState.Modified;
                //_dboContext.Set<T>().Update(obj);
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> Exists(Tkey id)
        {
            if (await GetAsync(id) != null) return true;

            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _dboContext.SaveChangesAsync();
        }
    }
}
