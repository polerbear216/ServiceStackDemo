using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Domain.Entity
{
    [Serializable]
    public abstract class Entity : IEntity
    {
        [Required]
        [AutoIncrement]
        [PrimaryKey]
        [Index]
        public long Id { get; set; }
    }

    public interface IEntity : IEntity<long>
    {
    }
}
