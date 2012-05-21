using System;
using System.Data.Objects;
using System.Linq;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Data.EntityFramework.Repositories
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private ObjectContext _context;
        public EFUserRepository(ObjectContext context)
            : base(context)
        {
            _context = context;
        }

        //private readonly YoyyinEntities1 _entities;

        //public EFUserRepository()
        //{
        //    _entities = new YoyyinEntities1();
        //}

        //public EFUserRepository(YoyyinEntities1 entities)
        //{
        //    _entities = entities;
        //}

        ////public IQueryable<User> Find()
        ////{
        ////    return _entities.User;
        ////}

        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(User user)
        //{
        //    var messages = from x in _entities.UserMessages where x.FromUserId == user.UserId select x;
        //    foreach (UserMessages message in messages)
        //        _entities.DeleteObject(message);

        //    var messages2 = from x in _entities.UserMessages where x.ToUserId == user.UserId select x;
        //    foreach (UserMessages message in messages2)
        //        _entities.DeleteObject(message);

        //    var comments = from x in _entities.UserComments where x.CommentUserId == user.UserId select x;
        //    foreach (UserComments comment in comments)
        //        _entities.DeleteObject(comment);

        //    comments = from x in _entities.UserComments where x.UserId == user.UserId select x;
        //    foreach (UserComments comment in comments)
        //        _entities.DeleteObject(comment);

        //    var visits = from x in _entities.UserVisits where x.UserId == user.UserId select x;
        //    foreach (UserVisits visit in visits)
        //        _entities.DeleteObject(visit);

        //    visits = from x in _entities.UserVisits where x.VisitingUserId == user.UserId select x;
        //    foreach (UserVisits visit in visits)
        //        _entities.DeleteObject(visit);

        //    var bookmarks = from x in _entities.UserBookmarks where x.UserId == user.UserId select x;
        //    foreach (UserBookmarks bookmark in bookmarks)
        //        _entities.DeleteObject(bookmark);

        //    bookmarks = from x in _entities.UserBookmarks where x.BookmarkedUserID == user.UserId select x;
        //    foreach (UserBookmarks bookmark in bookmarks)
        //        _entities.DeleteObject(bookmark);

        //    _entities.DeleteObject(_entities.User.FirstOrDefault(x => x.UserId == user.UserId));

        //    _entities.SaveChanges();
        //}

        //public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(User entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public User Create()
        //{
        //    throw new NotImplementedException();
        //}

        public IUser GetUser(Guid userId)
        {
            return Find(user => user.UserId == userId)
                    .First() as IUser;
        }

        //public int GetNumberOfUsers()
        //
        //    return _entities
        //            .ExecuteFunction<int>(Constants.SqlCount, new ObjectParameter[0])
        //            .First();
        //}

        //public IQueryable<User> GetAllUsersIncludingSni()
        //{
        //    return (from x in _entities.User.Include("SniHead").Include("SniItem") where x.Active == true && !string.IsNullOrEmpty(x.SniHeadID) orderby x.SniHeadID, x.SniNo select x);
        //}

        public IQueryable<User> GetLastActiveUsersWithImage()
        {
            return ObjectSet //.Include("aspnet_users") 
                .Where(u => u.Image != null)
                .OrderByDescending(user => user.aspnet_Users.LastActivityDate);
        }
    }
}