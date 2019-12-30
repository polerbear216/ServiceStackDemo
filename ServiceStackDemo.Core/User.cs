using ServiceStack.DataAnnotations;
using ServiceStackDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Core
{
    [Serializable]
    [Alias("DemoUser")]
    public class User : Entity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(int.MaxValue)]
        public string Password { get; set; }

        [StringLength(255)]
        [Required]
        public string UserName { get; set; }
        public int Age { get; set; }

        [StringLength(int.MaxValue)]
        public string Address { get; set; }
    }
}
