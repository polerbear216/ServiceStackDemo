using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStackDemo.Host.Model
{
    public class Authentication
    {
        public JwtBearer JwtBearer { get; set; }
    }

    public class JwtBearer
    {
        public bool IsEnabled { get; set; }

        public string SecurityKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int Expiration { get; set; }
    }


    public class ReqRegisterBody
    {
        public string UserName { get; set; }

        public string Pwd { get; set; }
    }
}
