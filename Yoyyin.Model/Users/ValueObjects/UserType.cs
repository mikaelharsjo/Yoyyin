namespace Yoyyin.Model.Users.ValueObjects
{
    public class UserType : IUserType
    {
        public string Title { get; set; }

        public string Description { get; set; }    
        
        public int UserTypeId { get; set; }
    }
}