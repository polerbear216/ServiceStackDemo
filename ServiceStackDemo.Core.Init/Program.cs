using System;
using ServiceStackDemo.Db;
using ServiceStack.OrmLite;

namespace ServiceStackDemo.Core.Init
{
    class Program
    {
        static void Main(string[] args)
        {
           var run= new DataRun();
            run.CreateTable();

            using (var db =run.OpenDbConnection())
            {
                var model = new User()
                {
                    Address = "sss",
                    Name = "张三",
                    Age = 20,
                    Password = EncryptHelper.Md5("`123qwe"),
                    UserName = "zhangsan"
                };
                db.Insert(model);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
