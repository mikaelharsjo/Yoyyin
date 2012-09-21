using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Yoyyin.Mvc.Transform;

namespace Yoyyin.Mvc.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/Scripts/bundled.js", new JsMinify()).Include(
                // jquery
                        "~/Scripts/lib/require-jquery.js",
                        "~/Scripts/lib/require.js"));

            var lessBundle = new Bundle("~/Content/Css/bundled.css").IncludeDirectory("~/Content/Less", "*.less");
            //lessBundle.Include("~/Content/Less/bootstrap.less");
            lessBundle.Transforms.Add(new LessTransform());
            lessBundle.Transforms.Add(new CssMinify());
            bundles.Add(lessBundle);
        }
    }
}