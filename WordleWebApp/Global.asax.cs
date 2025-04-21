using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WordleLogic;
using static System.Net.Mime.MediaTypeNames;

namespace WordleWebApp
{
    public class Global : HttpApplication
    {
    void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Initialization logic here to include the time you log into the wordle
            Application["AppStartTime"] = DateTime.Now;
            System.Diagnostics.Debug.WriteLine("Wordle Web App started at: " + Application["AppStartTime"]);
        }

        //void Application_End(object sender, EventArgs e)
        //{
            // Log last access or shutdown time
         //   string endMessage = "<hr />This page was last accessed at " + DateTime.Now.ToString();
        //    System.IO.File.AppendAllText(Server.MapPath("~/App_Data/app_log.txt"), endMessage + Environment.NewLine);
        //}



    }
}
