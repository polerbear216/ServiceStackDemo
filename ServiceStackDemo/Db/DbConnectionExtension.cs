using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Db
{
    public static class DbConnectionExtension
    {
        public static void UseDbConnection(this IApplicationBuilder app, IConfiguration configuration)
        {
            var dbConnections = ConfigurationBinder.Get<List<DbConnection>>(configuration.GetSection(typeof(DbConnection).Name));

            OrmLiteConfig.DialectProvider = MySqlDialect.Instance;

            foreach (var item in dbConnections)
            {
                if (string.IsNullOrWhiteSpace(item.ConnectionString) || string.IsNullOrWhiteSpace(item.ConnectionName))
                {
                    var msg = "ConnectionString Or ConnectionName Can Not Be NULL";
                    Console.WriteLine(msg);
                    throw new ArgumentNullException(msg);
                }

                IOrmLiteDialectProvider provider;
                if (item.DbType == DatabaseType.MySql)
                    provider = MySqlDialect.Instance;
                else
                    provider = SqlServerDialect.Instance;

                if (OrmLiteConnectionFactory.NamedConnections.ContainsKey(item.ConnectionName))
                {
                    var msg = $"ConnectionName is {item.ConnectionName} Is Already Register";
                    Console.WriteLine(msg);
                    throw new ArgumentException(msg);
                }

                DbFactory.Instance.RegisterConnection(item.ConnectionName, item.ConnectionString, provider);
            }
        }
    }
}
