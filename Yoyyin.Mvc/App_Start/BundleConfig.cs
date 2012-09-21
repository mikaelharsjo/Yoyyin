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
            bundles.Add(new Bundle("~/Scripts/bundled.js", new JsMinify())
                            .Include("~/Scripts/lib/require-jquery.js")
                            .Include("~/Scripts/lib/jquery.gomap-1.3.2.min.js")
                            .Include("~/Scripts/lib/bootstrap.js")
                            .Include("~/Scripts/lib/tag-it.js")
                            .Include("~/Scripts/lib/jquery.gomap-1.3.2.min.js")
                            .Include("~/Scripts/lib/require.js")
                            .Include("~/Scripts/yoyyin/yoyyin.quickSearch.js")
                            .Include("~/Scripts/yoyyin/yoyyin.init.js")
                            .Include("~/Scripts/yoyyin/registrationMain.js"));

            var lessBundle = new Bundle("~/Content/Css/bundled.css")//  .IncludeDirectory("~/Content/Less", "*.less");
                                .Include("~/Content/Less/yoyyin.less");

            lessBundle.Transforms.Add(new LessTransform());
            lessBundle.Transforms.Add(new CssMinify());
            bundles.Add(lessBundle);
        }
    }
}