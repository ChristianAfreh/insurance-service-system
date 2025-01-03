using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using InsuranceServiceApp.Extensions;
using InsuranceServiceApp.Repository.IRepository;
using InsuranceServiceApp.Models.Data;

namespace InsuranceServiceApp.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly InsuranceSystemDBContext _context;

        public BaseRepository(InsuranceSystemDBContext context)
        {
            _context = context;
        }

        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public virtual void CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void CreateRange(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().AddRange(entity);
        }
        public virtual void CreateRangeAsync(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().AddRangeAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().UpdateRange(entity);
        }

        public virtual IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity Find(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }



        public virtual TEntity Find(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).Count();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            Delete(entity);
        }


        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SaveChanges(int expectedResult, string errorMessage)
        {
            var result = _context.SaveChanges();

            if (result != expectedResult)
                throw new CustomException(errorMessage);
        }

        public IDbContextTransaction GetTransaction()
        {
            return _context.Database.BeginTransaction();
        }

    }
}
