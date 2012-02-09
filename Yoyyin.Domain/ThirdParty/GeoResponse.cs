using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Web;

namespace Yoyyin.Domain.ThirdParty
{
    [DataContract]
    public class GeoResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "results")]
        public CResult[] Results { get; set; }

        [DataContract]
        public class CResult
        {
            [DataMember(Name = "geometry")]
            public CGeometry Geometry { get; set; }

            [DataContract]
            public class CGeometry
            {
                [DataMember(Name = "location")]
                public CLocation Location { get; set; }

                [DataContract]
                public class CLocation
                {
                    [DataMember(Name = "lat")]
                    public double Lat { get; set; }
                    [DataMember(Name = "lng")]
                    public double Lng { get; set; }
                }
            }
        }

        public static GeoResponse CallGeoWs(string address)
        {
            string url = string.Format(
                    "http://maps.google.com/maps/api/geocode/json?address={0}&region=dk&sensor=false",
                    HttpUtility.UrlEncode(address)
                    );
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var serializer = new DataContractJsonSerializer(typeof(GeoResponse));
            var res = (GeoResponse)serializer.ReadObject(request.GetResponse().GetResponseStream());
            return res;
        }
    }
}



