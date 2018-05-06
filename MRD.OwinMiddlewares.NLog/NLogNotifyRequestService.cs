using MRD.OwinMiddlewares.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRD.OwinMiddlewares.DTOs;

namespace MRD.OwinMiddlewares.NLog
{
    public class NLogNotifyRequestService : INotifyRequestService
    {
        public async Task Notify(RequestInfo requestInfo)
        {
            global::NLog.MappedDiagnosticsLogicalContext.Set("RequestId", requestInfo.Id);
            global::NLog.MappedDiagnosticsLogicalContext.Set("URL", requestInfo.Uri.ToString());
            global::NLog.MappedDiagnosticsLogicalContext.Set("Method", requestInfo.Method);
            global::NLog.MappedDiagnosticsLogicalContext.Set("QueryString", requestInfo.QueryString);
            global::NLog.MappedDiagnosticsLogicalContext.Set("LocalIpAddress", requestInfo.LocalIpAddress);
            global::NLog.MappedDiagnosticsLogicalContext.Set("RemoteIpAddress", requestInfo.RemoteIpAddress);
            global::NLog.MappedDiagnosticsLogicalContext.Set("XForwardedFor", requestInfo.XForwardedFor);
        }
    }
}
