using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace MVCCookiesDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Dictionary<string, HttpSessionState> sessionData =
               new Dictionary<string, HttpSessionState>();
            Application["s"] = sessionData;
        }


        protected void Session_Start(object sender, EventArgs e)
        {
            Dictionary<string, HttpSessionState> sessionData =
              (Dictionary<string, HttpSessionState>)Application["s"];

            if (sessionData.Keys.Contains(HttpContext.Current.Session.SessionID))
            {
                sessionData.Remove(HttpContext.Current.Session.SessionID);
                sessionData.Add(HttpContext.Current.Session.SessionID,
                                HttpContext.Current.Session);
            }
            else
            {
                sessionData.Add(HttpContext.Current.Session.SessionID,
                                HttpContext.Current.Session);
            }
            Application["s"] = sessionData;
        }

        //Session End Event
        protected void Session_End(object sender, EventArgs e)
        {
            Dictionary<string, HttpSessionState> sessionData =
               (Dictionary<string, HttpSessionState>)Application["s"];
            sessionData.Remove(HttpContext.Current.Session.SessionID);
            Application["s"] = sessionData;
        }

    }
}
