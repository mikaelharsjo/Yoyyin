namespace Yoyyin.Model.Users.ValueObjects
{
    public interface IUserType
    {
        string Title { get; set; }
        string Description { get; set; }
        int UserTypeId { get; set; }
    }
}