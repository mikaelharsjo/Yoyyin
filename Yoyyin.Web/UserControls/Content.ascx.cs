using System;

namespace Yoyyin.Web.UserControls
{
    
    public partial class Content : System.Web.UI.UserControl
    {
        public string Html { get; set; }
        public int PageID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //lithtml.Text = "jquery rocks";
        }
    }
}