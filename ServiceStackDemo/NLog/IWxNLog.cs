using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStackDemo.NLog
{
    public interface IWxNLog
    {
        string Name { get; set; }
        void Info(string msg);
    }
}
