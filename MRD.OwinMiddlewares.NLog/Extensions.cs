using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRD.OwinMiddlewares.NLog
{
    public static class Extensions
    {
        public static IAppBuilder UseNLog(this IAppBuilder app, string logDirName = null)
        {
            NLogLogger.Init(logDirName);

            return app.NotifyRequestInfoWithNLog()
                .UseExceptionLoggerWithNLog()
                .UseRequestBodyLoggerWithNLog()
                .UseResponseBodyLoggerWithNLog();
        }
        public static IAppBuilder NotifyRequestInfoWithNLog(this IAppBuilder app)
        {
            return app.NotifyRequestInfo(new NLogNotifyRequestService());
        }
        public static IAppBuilder UseRequestBodyLoggerWithNLog(this IAppBuilder app)
        {
            return app.UseRequestBodyLogger(new NLogLogger());
        }
        public static IAppBuilder UseResponseBodyLoggerWithNLog(this IAppBuilder app)
        {
            return app.UseResponseBodyLogger(new NLogLogger());
        }
        public static IAppBuilder UseExceptionLoggerWithNLog(this IAppBuilder app)
        {
            return app.UseExceptionLogger(new NLogLogger());
        }
    }
}
