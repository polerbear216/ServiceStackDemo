using ServiceStack.DataAnnotations;
using ServiceStackDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Core
{
    [Alias("ChannelOrderInfos")]
    public class ChannelOrderInfo : Entity
    {
        public bool IsDeleted { get; set; }

        public string OrderCode { get; set; }
        /// <summary>
        /// 业务机会Id
        /// </summary>  
        public int BusinessChanceId { get; set; }

        public int BusinessChanceERPId { get; set; }

        /// <summary>
        /// 业务机会名称
        /// </summary>
        public string BusinessChanceName { get; set; }
    }
}
