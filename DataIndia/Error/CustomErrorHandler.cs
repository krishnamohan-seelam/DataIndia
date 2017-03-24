using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using NLog.Targets;

namespace DataIndia.Error
{
    public class CustomErrorHandler : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                Exception exception = filterContext.Exception;
                var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

                Logger logger = LogManager.GetLogger("FileLogger");
                logger.Error(exception.ToString());
                //  Find the correct target
                var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("FileTarget");
                Console.WriteLine(fileTarget.ToString());
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(model)

                };
                //ViewBag.FileName = fileTarget.FileName.ToString();
                //  Using the target, get the full path to the log file
                //string retval = Path.GetFullPath(fileTarget.FileName.Render());
            }


        }
    }
}