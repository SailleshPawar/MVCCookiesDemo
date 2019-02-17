using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MVCCookiesDemo.Controllers
{

    public class SessionValues
    {
 
        public string SessionId { get; set; }
        public string SessionKey { get; set; }
        public string SessionMode { get; set; }
    }

    

    public class ActiveSessionsController : Controller
    {


        // GET: ActiveSessions
        public ActionResult Index()
        {
            var session = getOnlineUsers();
            return View(session);
        }


        private List<SessionValues> getOnlineUsers()
        {
            List<SessionValues> activeSessions = new List<SessionValues>();

           
            Dictionary<string, HttpSessionState> sessionData =
              (Dictionary<string, HttpSessionState>)System.Web.HttpContext.Current.Application["s"];

            if (sessionData != null)
            {
                foreach (KeyValuePair<string, HttpSessionState> item in sessionData)
                {
                    activeSessions.Add(new SessionValues()
                    {
                        SessionId = item.Key,
                        SessionKey = item.Value.CookieMode.ToString(),
                        SessionMode = item.Value.Mode.ToString()
                    });
                    if (item.Value != null && item.Value.Count > 0)
                    {
                        foreach (string key in item.Value.Keys)
                        {
                            activeSessions.Add(new SessionValues()
                            {
                                SessionId = item.Key,
                                SessionKey = key,
                                SessionMode = item.Value[key] != null ?
                               item.Value[key].ToString() : string.Empty
                            });
                        }
                    }
                }
                
            }

        


            return activeSessions;
        }
    }


}