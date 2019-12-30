using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.Db
{
    public class DbConnection
    {
        public DatabaseType DbType { get; set; }
        public string ConnectionName { get; set; }
        public string ConnectionString { get; set; }
    }
    public enum DatabaseType
    {
        SqlServer = 0,
        MySql = 1
    }
}
