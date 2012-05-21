//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace Yoyyin.Data
{
    public partial class YoyyinEntities1 : ObjectContext
    {
        public const string ConnectionString = "name=YoyyinEntities1";
        public const string ContainerName = "YoyyinEntities1";
    
        #region Constructors
    
        public YoyyinEntities1()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public YoyyinEntities1(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public YoyyinEntities1(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<SniHead> SniHead
        {
            get { return _sniHead  ?? (_sniHead = CreateObjectSet<SniHead>("SniHead")); }
        }
        private ObjectSet<SniHead> _sniHead;
    
        public ObjectSet<SniItem> SniItem
        {
            get { return _sniItem  ?? (_sniItem = CreateObjectSet<SniItem>("SniItem")); }
        }
        private ObjectSet<SniItem> _sniItem;
    
        public ObjectSet<User> User
        {
            get { return _user  ?? (_user = CreateObjectSet<User>("User")); }
        }
        private ObjectSet<User> _user;
    
        public ObjectSet<Answer> Answer
        {
            get { return _answer  ?? (_answer = CreateObjectSet<Answer>("Answer")); }
        }
        private ObjectSet<Answer> _answer;
    
        public ObjectSet<Question> Question
        {
            get { return _question  ?? (_question = CreateObjectSet<Question>("Question")); }
        }
        private ObjectSet<Question> _question;
    
        public ObjectSet<Message> Message
        {
            get { return _message  ?? (_message = CreateObjectSet<Message>("Message")); }
        }
        private ObjectSet<Message> _message;
    
        public ObjectSet<Bookmark> Bookmark
        {
            get { return _bookmark  ?? (_bookmark = CreateObjectSet<Bookmark>("Bookmark")); }
        }
        private ObjectSet<Bookmark> _bookmark;
    
        public ObjectSet<Comment> Comment
        {
            get { return _comment  ?? (_comment = CreateObjectSet<Comment>("Comment")); }
        }
        private ObjectSet<Comment> _comment;
    
        public ObjectSet<Visit> Visit
        {
            get { return _visit  ?? (_visit = CreateObjectSet<Visit>("Visit")); }
        }
        private ObjectSet<Visit> _visit;
    
        public ObjectSet<aspnet_Users> aspnet_Users
        {
            get { return _aspnet_Users  ?? (_aspnet_Users = CreateObjectSet<aspnet_Users>("aspnet_Users")); }
        }
        private ObjectSet<aspnet_Users> _aspnet_Users;

        #endregion
        #region Function Imports
        public ObjectResult<string> usp_AutoComplete_Get()
        {
            return base.ExecuteFunction<string>("usp_AutoComplete_Get");
        }
        public ObjectResult<Nullable<System.Guid>> usp_User_GetPopular()
        {
            return base.ExecuteFunction<Nullable<System.Guid>>("usp_User_GetPopular");
        }
        public ObjectResult<usp_YAF_GetCategoriesAndForums_Result> usp_YAF_GetCategoriesAndForums(Nullable<int> boardID)
        {
    
            ObjectParameter boardIDParameter;
    
            if (boardID.HasValue)
            {
                boardIDParameter = new ObjectParameter("BoardID", boardID);
            }
            else
            {
                boardIDParameter = new ObjectParameter("BoardID", typeof(int));
            }
            return base.ExecuteFunction<usp_YAF_GetCategoriesAndForums_Result>("usp_YAF_GetCategoriesAndForums", boardIDParameter);
        }
        public ObjectResult<Nullable<int>> usp_User_GetCount()
        {
            return base.ExecuteFunction<Nullable<int>>("usp_User_GetCount");
        }
        public ObjectResult<string> usp_SearchWords_GetAll()
        {
            return base.ExecuteFunction<string>("usp_SearchWords_GetAll");
        }

        #endregion
    }
}
