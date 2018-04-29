using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRD.OwinMiddlewares.NLog
{
    public class NLogLogger : ILogger
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
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
