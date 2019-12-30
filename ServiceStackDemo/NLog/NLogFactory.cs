using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceStackDemo.NLog
{
    public static class NLogFactory
    {
        private static IList<IWxNLog> _loggers = new List<IWxNLog>();
        private static object locker = new object();
        public static IWxNLog GetWxLogger<T>()
        {
            return GetWxLogger(typeof(T));
        }
        public static IWxNLog GetWxLogger(Type type = null)
        {
            lock (locker)
            {
                if (type == (Type)null)
                {
                    type = typeof(WxNLog);
                }
                IWxNLog wxLog = _loggers.SingleOrDefault((IWxNLog l) => l.Name == type.FullName);
                if (wxLog == null)
                {
                    wxLog = new WxNLog(type.FullName);
                    _loggers.Add(wxLog);
                }
                return wxLog;
            }
        }

    }

}
