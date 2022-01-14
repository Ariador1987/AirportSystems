using FlightManagment.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlightManagment.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            return entity is not null;
        }

        public async Task<List<T>> GetAllAsync() => await _db.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}