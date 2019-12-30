using ServiceStack.DataAnnotations;
using ServiceStackDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Core
{
    [Alias("BusinessChances")]
    public class BusinessChance : Entity<int>
    {
        /// <summary>
        /// 创建人Id
        /// </summary>
        public virtual Guid PassportId { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual int? CustormerId { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [StringLength(50)]
        public virtual string ProjectCode { get; set; }

        /// <summary>
        /// 机会名称
        /// </summary>
        [StringLength(500)]
        public virtual string ChanceName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 机会类型
        /// </summary>
        public virtual int ChanceType { get; set; }

        /// <summary>
        /// 机会阶段
        /// </summary>
        public virtual int ChanceStage { get; set; }

    }
}
