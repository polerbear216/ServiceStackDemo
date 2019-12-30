using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStackDemo.Core;

namespace ServiceStackDemo.Core.Init
{
    public class DataRun
    {
#if MYSQL
        private static string DefalutConnectionString = "server=127.0.0.1;user id=root;password=`123qwe;persistsecurityinfo=True;port=3306;database=mytest;SslMode=none";
        public DataRun()
        {
          OrmLiteConfig.DialectProvider =MySqlDialect.Instance;
        }
#else
        private static string DefalutConnectionString = "Server=.; Database=MyTest;User ID=sa;Password=`123qwe;MultipleActiveResultSets=true;";
        public DataRun()
        {
            OrmLiteConfig.DialectProvider = SqlServerDialect.Instance;
        }
#endif
        
        public string ConnectionString { get; set; }

        public DataRun(string connectionString) : this()
        {
            ConnectionString = connectionString;
        }
        public IDbConnection OpenDbConnection(string connectionString = null, IOrmLiteDialectProvider provider = null)
        {
            connectionString = connectionString ?? DefalutConnectionString;
            provider = provider ?? OrmLiteConfig.DialectProvider;

            return new OrmLiteConnectionFactory(connectionString, provider).OpenDbConnection();
        }

        public Type[] GetTables()
        {
            return new Type[]
            {
                typeof(User)
            };
        }


        public void CreateTable()
        {
            using (var db = OpenDbConnection())
            {
                var provider = db.GetDialectProvider();
                var stringConverter = provider.GetStringConverter();
                stringConverter.UseUnicode = true;

                db.CreateTableIfNotExists(GetTables());
            }

        }

    }

}
