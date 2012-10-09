namespace Yoyyin.Model.Users.ValueObjects
{
    public class Address
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        public Coordinate Coordinate { get; set; }
 
    }
}