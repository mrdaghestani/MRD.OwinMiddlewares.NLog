using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Config;
using NLog.Targets;

namespace MRD.OwinMiddlewares.NLog
{
    public class NLogLogger : ILogger
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        internal static void Init(string logDirName = null)
        {
            if (LogManager.Configuration != null)
            {
                if (string.IsNullOrEmpty(logDirName))
                {
                    logDirName = ConfigurationManager.AppSettings["NLog.DirName"] ?? "MRD";
                }

                LogManager.Configuration.Variables["LogDirName"] = logDirName;
            }

            _logger.Trace($"NLog Config Inited.");
        }
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        public void Debug(string log)
        {
            _logger.Debug(log);
        }

        public void Fatal(Exception exception)
        {
            _logger.Fatal(exception);
        }
    }
}
