using System;
using Yoyyin.Domain.Services;
using Yoyyin.Web.Helpers;
using System.Linq;

namespace Yoyyin.Web
{
    public partial class Members : System.Web.UI.Page
    {
        public ISniHeadService SniHeadService;

        protected void Page_Load(object sender, EventArgs e)
        {
            var sniHeads = from g in SniHeadService.GetAllSniIncludingUsers()
                               .GroupBy(sniHead => sniHead.SniItem)
                           let firstSniHead = g.First()
                           select

                               new
                                   {
                                       firstSniHead.Title, firstSniHead.SniHeadID, 
                                       firstSniHead.User,
                                       SniItemTitle = "TODO:" //firstSniHead.SniItem.Last().Title
                                   };

            //TODO: group by sniItem

            lstSniHeads.DataSource = sniHeads;
            lstSniHeads.DataBind();
        }

        #region Data bind

        //protected string GetSniHeadTitle(object dataItem)
        //{
        //    var user = (User)dataItem;

        //    string retVal = string.Empty;
        //    if (user.SniHead != null)
        //    {
        //        if (Session["CurrentSniHeadID"] == null)
        //        {
        //            Session["CurrentSniHeadID"] = user.SniHeadID;
        //            return user.SniHead.Title;
        //        }
        //        if (Session["CurrentSniHeadID"].ToString() != user.SniHeadID)
        //        {
        //            Session["CurrentSniHeadID"] = user.SniHeadID;
        //            retVal = user.SniHead.Title;
        //        }
        //    }
        //    return retVal;
        //}

        //protected string GetSniHeadID(object dataItem)
        //{
        //    var user = (User)dataItem;

        //    if (user.SniHead != null)
        //        return user.SniHeadID;
            
        //    return string.Empty;
        //}

        //protected string GetSniItemTitle(object dataItem)
        //{
        //    var user = (User)dataItem;
        //    string retVal = string.Empty;
        //    if (user.SniItem != null)
        //    {
        //        if (Session["CurrentSniItemID"] == null)
        //        {
        //            Session["CurrentSniItemID"] = user.SniNo;
        //            return user.SniItem.Title;
        //        }
        //        if (Session["CurrentSniItemID"].ToString() != user.SniNo)
        //        {
        //            Session["CurrentSniItemID"] = user.SniNo;
        //            retVal = user.SniItem.Title;
        //        }
        //    }
        //    return retVal;
        //}

        #endregion

        protected string AddSecretLinkIfNotLogedIn()
        {
            return WebHelpers.IsLoggedIn() ? string.Empty : "secretLink";
        }
    }
}