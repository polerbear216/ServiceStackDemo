using ServiceStack.OrmLite;
using ServiceStackDemo.Dependency;
using ServiceStackDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ServiceStackDemo.Domain.Repository
{
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey>
    {
        string ConnectionName { get;  set; }
        long Count();
        long Count(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(TPrimaryKey id);
        List<TEntity> GetList();
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetPageList(Expression<Func<TEntity, bool>> whereExpression = null, Expression<Func<TEntity, object>> orderByExpression = null, int pageIndex = 0, int pageSize = 10);

        int Delete(TEntity entity);
        int DeleteById(TPrimaryKey id);
        int DeleteByIds(IEnumerable<TPrimaryKey> ids);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        int Delete(SqlExpression<TEntity> whereExpression);
        int DeleteAll(IEnumerable<TEntity> rows);

        void Insert(params TEntity[] entitys);
        void InsertAll(IEnumerable<TEntity> entitys);

        bool Save(TEntity entity);
        int Save(params TEntity[] entitys);
        int SaveAll(IEnumerable<TEntity> entitys);

        int Update(TEntity entity);
        int Update(params TEntity[] entitys);
        int UpdateAll(IEnumerable<TEntity> entitys);

        IRepository<TEntity, TPrimaryKey> Set(string connectionName);
    }
}
