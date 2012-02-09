using System;
using System.Collections.Generic;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.Web.UserControls
{
    public partial class ForumChoose : System.Web.UI.UserControl
    {
        public string Text { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lstForum.DataSource = EnumHelper.GetAll<CategoryType>();
            lstForum.DataBind();
        }

        protected string GetDescription(object dataItem)
        {
            var category = GetCurrentCategory(dataItem);

            return category.GetDescription();
        }

        private static CategoryType GetCurrentCategory(object dataItem)
        {
            var keyValuePair = (KeyValuePair<string, int>) dataItem;
            var category = (CategoryType) Enum.Parse(typeof (CategoryType), keyValuePair.Key);
            return category;
        }

        protected string GetTitle(object dataItem)
        {
            var category = GetCurrentCategory(dataItem);
            return category.GetTitle();
        }
    }
}