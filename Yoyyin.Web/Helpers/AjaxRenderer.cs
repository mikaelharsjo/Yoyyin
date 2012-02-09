using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Yoyyin.Web.Helpers
{
    public class AjaxRenderer
    {
        /// <summary>/// Renders a user control into a string/// </summary>/// 
        /// <param name="userControlVirtualPath"></param>/// <param name="includePostbackControls">
        /// If false renders using RenderControl, otherwise uses Server.Execute() constructing a new form.
        /// IF the user control has a Data property.</param>/// <returns></returns>
        public static string RenderUserControl(string userControlVirtualPath, bool includePostbackControls, Dictionary<string, object> parameters, bool addScriptmanager)
        {
            // const string STR_NoUserControlDataProperty = "Passed a Data parameter to RenderUserControl, but the user control has no public Data property.";
            const string strBeginRenderControlBlock = "<!-- BEGIN RENDERCONTROL BLOCK -->";
            const string strEndRenderControlBlock = "<!-- End RENDERCONTROL BLOCK -->";
            var tw = new StringWriter();
            Control control = null;
            if (!includePostbackControls)
            {        // *** Simple rendering works if no post back controls are used        
                var curPage = (Page)HttpContext.Current.Handler;
                control = curPage.LoadControl(userControlVirtualPath);

                foreach (KeyValuePair<string, object> kvp in parameters)
                {
                    SetValue(control, kvp.Key, kvp.Value);
                }
                return RenderControl(control);
            }
            // *** Create a page and form so that postback controls work              
            var page = new Page { EnableViewState = false };
            // *** IMPORTANT: Control must be loaded of this NEW page context or call will fail  
            var sc = new ScriptManager();

            control = page.LoadControl(userControlVirtualPath);
            foreach (var kvp in parameters)
            {
                SetValue(control, kvp.Key, kvp.Value);
            }

            var form = new HtmlForm { ID = "__t" };
            page.Controls.Add(form);
            if (addScriptmanager)
                form.Controls.Add(sc);
            form.Controls.Add(new LiteralControl(strBeginRenderControlBlock));
            form.Controls.Add(control);
            form.Controls.Add(new LiteralControl(strEndRenderControlBlock));

            HttpContext.Current.Server.Execute(page, tw, true);

            string html = tw.ToString();
            // *** Strip out form and ViewState, Event Validation etc.    
            html = ExtractString(html, strBeginRenderControlBlock, strEndRenderControlBlock);
            return html;
        }

        public static string RenderControl(Control control)
        {
            var tw = new StringWriter();
            // *** Simple rendering - just write the control to the text writer    
            // *** works well for single controls without containers    
            var writer = new Html32TextWriter(tw);
            control.RenderControl(writer);
            writer.Close();
            writer.Dispose();
            string retVal = tw.ToString();
            tw.Dispose();
            return retVal;
        }

        static void SetValue(Control control, string propertyName, object propertyValue)
        {

            Type viewControlType = control.GetType();
            PropertyInfo property =
                viewControlType.GetProperty(propertyName);

            if (property != null)
            {
                property.SetValue(control, propertyValue, null);
            }
            else
            {
                throw new Exception(string.Format(
                    "UserControl: {0} does not have a public {1} property.",
                    viewControlType.Name, propertyName));
            }
        }

        public static string ExtractString(string str, string start, string end)
        {
            int startPos = str.IndexOf(start) + start.Length;
            int endPos = str.IndexOf(end) - startPos;
            return str.Substring(startPos, endPos);
        }
    }
}