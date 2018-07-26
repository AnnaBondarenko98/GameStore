using System.Web.Mvc;
using System.Web.Routing;
using NLog;

namespace GameStore.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception != null)
            {
                _logger.Error($" Error message : {filterContext.Exception.Message}, place : {filterContext.Controller}");
                filterContext.Result = new RedirectToRouteResult("Error", new RouteValueDictionary(new { id = filterContext.Exception.Message.Length > 200 ? filterContext.Exception.Message.Remove(200) : filterContext.Exception.Message }));
                filterContext.ExceptionHandled = true;
            }
        }
    }
}