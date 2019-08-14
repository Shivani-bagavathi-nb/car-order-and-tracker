using System.Collections.Generic;

namespace CarOrder.Aggregate.Repos.Repository.Interfaces
{
    public interface IUserRepository1<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity dbEntity);
    }
}