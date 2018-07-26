using System.Web.Mvc;
using Autofac.Integration.Mvc;
using GameStore.Web.Filters;
using NLog;

namespace GameStore.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            var logger = AutofacDependencyResolver.Current.GetService<ILogger>();

            filters.Add(new ExceptionFilter(logger));
            filters.Add(new ActionFilter(logger));
        }
    }
}