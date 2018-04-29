using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRD.OwinMiddlewares.NLog
{
    public static class Extensions
    {
        public static IAppBuilder UseNLog(this IAppBuilder app)
        {
            //global::NLog.LogManager.Configuration

            return app.NotifyRequestInfoWithNLog()
                .UseExceptionLoggerWithNLog()
                .UseRequestBodyLoggerWithNLog()
                .UseResponseBodyLoggerWithNLog();
        }
        public static IAppBuilder NotifyRequestInfoWithNLog(this IAppBuilder app)
        {
            return app.NotifyRequestInfo(info =>
            {
                global::NLog.MappedDiagnosticsLogicalContext.Set("RequestId", info.Id);
                global::NLog.MappedDiagnosticsLogicalContext.Set("URL", info.Uri.ToString());
                global::NLog.MappedDiagnosticsLogicalContext.Set("Method", info.Method);
                global::NLog.MappedDiagnosticsLogicalContext.Set("QueryString", info.QueryString);
                global::NLog.MappedDiagnosticsLogicalContext.Set("LocalIpAddress", info.LocalIpAddress);
                global::NLog.MappedDiagnosticsLogicalContext.Set("RemoteIpAddress", info.RemoteIpAddress);
                global::NLog.MappedDiagnosticsLogicalContext.Set("XForwardedFor", info.XForwardedFor);

            });
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
