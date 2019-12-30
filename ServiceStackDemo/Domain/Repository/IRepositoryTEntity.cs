using ServiceStackDemo.Dependency;
using ServiceStackDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Domain.Repository
{
    public interface IRepository<TEntity> : IRepository<TEntity, long> where TEntity : class, IEntity<long>
    {
        long InsertAndGetId(TEntity entity);
    }

    public interface IRepository: ITransientDependency
    {
    }
}
