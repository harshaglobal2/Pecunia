using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Inventory.Mvc
{
    public class BundleConfig
    {
        //Will be called on first request
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Bundle for jQuery and Popper.js
            bundles.Add(
                new ScriptBundle("~/scripts/jquery")
                .Include(
                    "~/Scripts/jquery-3.4.1.js",
                    "~/Scripts/umd/popper.js"
                ));

            //Bundle for jQuery Validation
            bundles.Add(
                new ScriptBundle("~/scripts/jqueryvalidation")
                .Include(
                    "~/Scripts/jquery.validate.js",
                    "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            //Bundle for Bootstrap
            bundles.Add(
                new ScriptBundle("~/scripts/bootstrap")
                .Include(
                    "~/Scripts/bootstrap.js"
                ));

            //Bundle for Bootstrap CSS
            bundles.Add(
                new StyleBundle("~/styles/bootstrap")
                .Include(
                    "~/Content/bootstrap.css"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}


