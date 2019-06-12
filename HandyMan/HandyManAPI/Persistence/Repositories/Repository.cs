using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using HandyManAPI.Core.Repositories;

namespace HandyManAPI.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entity;

        public Repository(DbContext context)
        {
            this.Context = context;
            this._entity = Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entity.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
           _entity.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Where(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Any(predicate);
        }

        public TEntity Get(int id)
        {
            return _entity.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entity.ToList();
        }

        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
           _entity.RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.SingleOrDefault(predicate);
        }
    }

}