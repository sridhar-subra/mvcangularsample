using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class NLogLogger : ILogger
    {
        private readonly Logger logger;

        public NLogLogger()
        {
            logger = LogManager.GetCurrentClassLogger();
        }


        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }


        public void Error(string message, Exception exception)
        {
            logger.Log(LogLevel.Fatal, message, exception);
        }


    }
}
