using System.Collections.Generic;
using System.Linq;
using BaseProject.Domain.Entities;

namespace BaseProject.Domain.IRepositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity obj);
        void AddAll(IEnumerable<TEntity> obj);
        void DeleteAll(IEnumerable<TEntity> obj);
        void Delete(TEntity obj);
        void Delete(int id);

        TEntity Get(int id);

        TEntity First();
        IQueryable<TEntity> Get();
        void Update(TEntity obj);

        void Commit();

        void AddOrUpdate(TEntity obj);
    }

}