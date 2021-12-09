using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PersonelMvcUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/scripts").Include(
                "~/Scripts/jquery-3.6.0.min.js",
               "~/ Scripts / bootstrap.min.js",
               "~/Scripts/bootbox.min.js",
               "~/Scripts/jquery.unobtrusive-ajax.min.js",
               "~/Scripts/Login.js",
               "~/Scripts/custom.js"
                ));
        }
    }
}