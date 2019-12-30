using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.NLog
{
    internal class WxNLog : IWxNLog
    {
        public string Name { get; set; }
        public WxNLog(string name)
        {
            Name = name;
        }
        public void Info(string msg)
        {
            Console.WriteLine($"[INFO]|{msg}");
            LogManager.GetLogger(Name).Info(msg);
        }
    }
}
