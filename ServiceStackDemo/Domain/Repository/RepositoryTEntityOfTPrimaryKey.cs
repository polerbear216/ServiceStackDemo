using ServiceStack.OrmLite;
using ServiceStackDemo.Db;
using ServiceStackDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace ServiceStackDemo.Domain.Repository
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    {
        public string ConnectionName { get; set; }
        public long Count()
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Count<TEntity>();
            }
        }
        public long Count(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Count(predicate);
            }
        }

        public TEntity Get(TPrimaryKey id)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.SingleById<TEntity>(id);
            }
        }
        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Exists<TEntity>(predicate);
            }
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                 return db.Single<TEntity>(db.From<TEntity>().Where(predicate));
            }
        }

        public List<TEntity> GetList()
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Select<TEntity>();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Select<TEntity>(db.From<TEntity>().Where(predicate));
            }

        }

        public List<TEntity> GetPageList(Expression<Func<TEntity, bool>> whereExpression = null, Expression<Func<TEntity, object>> orderByExpression = null, int pageIndex = 0, int pageSize = 10)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                var condition = db.From<TEntity>();
                if (whereExpression != null) condition = condition.Where(whereExpression);
                if (orderByExpression != null) condition = condition.OrderBy(orderByExpression);

                return db.Select<TEntity>(condition.Skip(pageIndex * pageSize).Take(pageSize));
            }
        }

        public int Delete(TEntity entity)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Delete<TEntity>(entity);
            }
        }
        public int DeleteById(TPrimaryKey id)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.DeleteById<TEntity>(id);
            }
        }
        public int DeleteByIds(IEnumerable<TPrimaryKey> ids)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.DeleteByIds<TEntity>(ids);
            }
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Delete(predicate);
            }
        }
        public int Delete(SqlExpression<TEntity> whereExpression)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Delete(whereExpression);
            }
        }
        public int DeleteAll(IEnumerable<TEntity> rows)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.DeleteAll<TEntity>(rows);
            }
        }
        public void Insert(params TEntity[] entitys)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                db.Insert<TEntity>(entitys);
            }
        }
        public void InsertAll(IEnumerable<TEntity> entitys)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                db.InsertAll<TEntity>(entitys);
            }
        }
        public bool Save(TEntity entity)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Save<TEntity>(entity);
            }
        }
        public int Save(params TEntity[] entitys)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Save<TEntity>(entitys);
            }
        }
        public int SaveAll(IEnumerable<TEntity> entitys)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.SaveAll<TEntity>(entitys);
            }
        }

        public int Update(TEntity entity)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Update<TEntity>(entity);
            }
        }
        public int Update(params TEntity[] entitys)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Update<TEntity>(entitys);
            }
        }
        public int UpdateAll(IEnumerable<TEntity> entitys)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.UpdateAll<TEntity>(entitys);
            }
        }

        public IRepository<TEntity, TPrimaryKey> Set(string connectionName)
        {
            this.ConnectionName = connectionName;
            return this;
        }

    }
}
