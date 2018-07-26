using System.Diagnostics;
using System.Web.Mvc;
using NLog;

namespace GameStore.Web.Filters
{
    public class ActionFilter: FilterAttribute,IActionFilter
    {
        private readonly ILogger _logger;

        private Stopwatch serviceStopwatch;

        public ActionFilter(ILogger logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.Info($"Request's IP : {filterContext.HttpContext.Request.UserHostAddress}");
            _logger.Info($"Start executing action {filterContext.ActionDescriptor.ActionName}");

            serviceStopwatch = Stopwatch.StartNew();
            serviceStopwatch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            serviceStopwatch.Stop();

            _logger.Info($"End of action {filterContext.ActionDescriptor.ActionName} call. Time : {serviceStopwatch.Elapsed}");
        }
    }
}