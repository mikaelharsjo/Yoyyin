using Yoyyin.Data;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.ThirdParty
{
    public class GoogleHelper
    {
        public void UpdateUserCoordsFromGeocodingService(IUser user)
        {
            try
            {
                string strAddress = user.Street + "+" + user.ZipCode + "+" + user.City;
                strAddress = strAddress.Replace(" ", "+");
                var geoResponse = GeoResponse.CallGeoWs(strAddress);

                if (geoResponse.Status == "OK")
                {
                    user.Latitude = geoResponse.Results[0].Geometry.Location.Lat;
                    user.Longitude = geoResponse.Results[0].Geometry.Location.Lng;
                }
            }
            catch { /* Google is down */ }
        }
    }
}
