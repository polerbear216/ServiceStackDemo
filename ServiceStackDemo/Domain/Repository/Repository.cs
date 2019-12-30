using ServiceStack.OrmLite;
using ServiceStackDemo.Db;
using ServiceStackDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Domain.Repository
{
    public class Repository<TEntity> : Repository<TEntity, long> where TEntity : class, IEntity<long>
    {
        public long InsertAndGetId(TEntity entity)
        {
            using (var db = DbFactory.OpenDbConnection(ConnectionName))
            {
                return db.Insert(entity, true);
            }
        }
    }
}
