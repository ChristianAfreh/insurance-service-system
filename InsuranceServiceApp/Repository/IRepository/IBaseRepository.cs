
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace InsuranceServiceApp.Repository.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entity);
        void CreateRangeAsync(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(int id);
        int Count(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        void Delete(int id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void SaveChanges(int expectedResult, string errorMessage);

    }
}
