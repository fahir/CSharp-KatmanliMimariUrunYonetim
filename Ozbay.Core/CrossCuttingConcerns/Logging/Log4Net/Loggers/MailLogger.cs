using log4net;

namespace OZBAY.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class MailLogger : LoggerService
    {
        public MailLogger() : base(LogManager.GetLogger("MailLogger"))
        {
        }
    }
}
