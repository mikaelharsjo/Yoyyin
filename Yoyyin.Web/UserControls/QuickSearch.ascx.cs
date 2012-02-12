using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web.UserControls
{
    public partial class QuickSearch : UserControl
    {
        public string Text { get; set; }
        public int Counter { get; set; }
        public int GeoCounter { get; set; }
        public string MapCoords { get; set; }
        const string Info = "<strong>{0}:</strong><br/>{1}";
        public IUserService UserService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var hits = UserService.SearchQuick(Text);
            Counter = hits.Count();

            if (Counter > 0)            
                CreateGoogleMapsScript(hits);            
            else
            {
                map_canvas.Visible = false;
                lnkShowMap.Visible = false;
                litNoHits.Text = "Din sökning gav tyvärr inget resultat. Gör gärna om sökningen med andra sökord. Tänk på att:<ul><li>Kontrollera att alla ord är rättstavade.</li><li>Försök med andra, färre eller mer allmänna sökord.</li></ul>";
            }

            hiddenCount.Value = Counter.ToString();
            usersControl.SrcUsers = hits;
            usersControl.DataBind();
        }

        private void CreateGoogleMapsScript(IEnumerable<IUser> hits)
        {
            var sb = new StringBuilder();
            int index = 0;
            string lat = string.Empty;
            string lng = string.Empty;
            sb.Append("var bounds = new google.maps.LatLngBounds();");

            foreach (User user in hits)
            {
                if (user.Latitude != null && user.Longitude != null && user.ShowOnMap)
                {
                    index++;
                    lat = user.Latitude.ToString().Replace(",", ".");
                    lng = user.Longitude.ToString().Replace(",", ".");
                    sb.Append("var lat = " + lat + ";");
                    sb.Append("var long = " + lng + ";");
                    sb.Append("var point = new google.maps.LatLng(lat, long);");
                    sb.Append("bounds.extend(point);");

                    string marker = "marker" + index;
                    string infoWindow = "infoWindow" + index;
                    string info = string.Format(Info, user.GetDisplayName(), user.BusinessDescription.Truncate(400));
                    info = info.Replace("\n", "<br />");
                    info = info.Replace("\r", "<br />");
                    info = info.Replace("\t", "");
                    sb.Append("var " + infoWindow + " = new google.maps.InfoWindow({content: '" + info + "'});");

                    sb.Append("var " + marker + " = new google.maps.Marker({ position : point, map: map, title: '" + user.Name + "' });");
                    sb.Append("google.maps.event.addListener(" + marker + ", 'click', function() {" + infoWindow + ".open(map," + marker + ");});");
                }
            }

            if (index > 0)
            {
                MapCoords = "var latlng = new google.maps.LatLng(" + lat + ", " + lng + ");var myOptions = { zoom: 11, center: latlng, scrollwheel: false, mapTypeId: google.maps.MapTypeId.TERRAIN }; var map = new google.maps.Map(document.getElementById('map_canvas'), myOptions); " + sb.ToString() + "; map.fitBounds(bounds);";  //map.setCenter(bounds.getCenter()); map.setZoom(map.getBoundsZoomLevel(bounds));";

                if (hits.Count() == 1)
                    MapCoords += "; map.setZoom(12);";
            }
            else
            {
                map_canvas.Visible = false;
                lnkShowMap.Visible = false;
            }
        }

        protected void Item_DataBound(object sender, ListViewItemEventArgs e)
        {
            if (!WebHelpers.IsLoggedIn())
            {
                HtmlAnchor control = (HtmlAnchor)e.Item.FindControl("lnkReadMore"); 
                control.Attributes.Add("class", "secretLink");
            }
        }

        #region Data Bind





        protected string GetSni(object dataItem)
        {
            var user = (User)dataItem;
            return user.SniItem.Title;
        }

        #endregion
    }
}