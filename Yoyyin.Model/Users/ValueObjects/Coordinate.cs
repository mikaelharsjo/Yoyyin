namespace Yoyyin.Model.Users.ValueObjects
{
    public class Coordinate //: ICoordinate
    {
        //public Coordinate(double latitude, double longitude)
        //{
        //    Latitude = latitude;
        //    Longitude = longitude;
        //}

        public Coordinate()
        {
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; } 
    }
}