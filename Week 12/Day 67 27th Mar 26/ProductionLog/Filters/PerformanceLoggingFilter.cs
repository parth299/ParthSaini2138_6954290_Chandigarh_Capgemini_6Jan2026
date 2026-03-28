using Microsoft.AspNetCore.Mvc.Filters;
using log4net;
using System.Diagnostics;

namespace ProductionLog.Filters
{
    public class PerformanceLoggingFilter : IActionFilter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PerformanceLoggingFilter));
        private Stopwatch stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
            log.Info($"API Started: {context.ActionDescriptor.DisplayName}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();

            var duration = stopwatch.Elapsed.TotalSeconds;

            if (context.Exception != null)
            {
                log.Error("API failed", context.Exception);
                return;
            }

            if (duration > 3)
            {
                log.Warn($"Slow API detected: {duration} sec");
            }
            else
            {
                log.Info($"API Completed in {duration} sec");
            }
        }
    }
}