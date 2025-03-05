using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRiraRepository<T> where T : class
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        List<T> AddRange(IEnumerable<T> entities);
        bool Exists(Expression<Func<T, bool>> filter);
        IQueryable<T> Find(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        T GetById(object id);
        void Remove(T entity);
        void RemoveById(object id);
        void RemoveRange(IEnumerable<T> entities);
        void SaveChanges();
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }

    public class RiraRepository<T> : IRiraRepository<T> where T : class
    {
        private readonly RiraContext _context;

        public RiraRepository(RiraContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {

            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public List<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();

            return entities.ToList();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            DbSet<T> dbSet1 = _context.Set<T>();
            IQueryable<T> query = dbSet1;

            query = query.Where(filter);
            return query;
        }

        public bool Exists(Expression<Func<T, bool>> filter)
        {
            DbSet<T> dbSet1 = _context.Set<T>();
            IQueryable<T> query = dbSet1;

            bool res = query.Any(filter);
            return res;
        }

        public IQueryable<T> GetAll()
        {
            DbSet<T> dbSet1 = _context.Set<T>();
            IQueryable<T> query = dbSet1;
            return query;
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

        }

        public void RemoveById(object id)
        {

            var entity = _context.Set<T>().Find(id);

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {

            _context.Set<T>().Update(entity);
            _context.SaveChanges();

        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
