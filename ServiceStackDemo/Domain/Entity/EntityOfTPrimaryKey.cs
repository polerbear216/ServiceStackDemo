using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Domain.Entity
{
    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [Required]
        [PrimaryKey]
        [Index]
        public TPrimaryKey Id { get; set; }
    }

    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
