using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStackDemo.Db
{
    public static class DbFactory
    {
        internal static OrmLiteConnectionFactory Instance = new OrmLiteConnectionFactory();

        private static string DefaultConnectionName = "Default";

        public static IDbConnection OpenDbConnection(string connectionName = null)
        {
            connectionName = connectionName ?? DefaultConnectionName;
            return Instance?.OpenDbConnection(connectionName);
        }
        public static Task<IDbConnection> OpenDbConnectionAsync(string connectionName = null)
        {
            connectionName = connectionName ?? DefaultConnectionName;
            return Instance?.OpenDbConnectionAsync(connectionName);
        }

    }
}
