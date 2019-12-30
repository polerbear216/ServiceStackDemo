using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.OrmLite;
using ServiceStackDemo.Core;
using ServiceStackDemo.Domain.Repository;
using NLog;
namespace ServiceStackDemo.Host.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRepository<ChannelOrderInfo, long> _orderInfoRepository;
        private readonly IRepository<BusinessChance, int> _buspository;
        private readonly IRepository<User, long> _userRepository;

        public ValuesController(
            IRepository<ChannelOrderInfo, long> orderInfoRepository
           , IRepository<BusinessChance, int> buspository
           , IRepository<User, long> userRepository
            )
        {
            _orderInfoRepository = orderInfoRepository;
            _buspository = buspository;
            _userRepository = userRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
           // LogManager.GetLogger(this.GetType().FullName).Info("sssss");

            var user1 = _userRepository.Set("MySqlDb").Get(1);
            var user2 = _userRepository.Set("Default").Get(1);

            return Ok(new { user1, user2 });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<string> Get(int id)
        {
            return "";
        }

    }
}
