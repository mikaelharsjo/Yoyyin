//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Yoyyin.Data.Core;
using Yoyyin.Data.Core.Entities;


namespace Yoyyin.Data
{
    public partial class Bookmark : IBookmark
    {
        #region Primitive Properties
    
        public virtual System.Guid UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    if (User != null && User.UserId != value)
                    {
                        User = null;
                    }
                    _userId = value;
                }
            }
        }
        private System.Guid _userId;
    
        public virtual System.Guid BookmarkedUserID
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> Created
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual IUser User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
                    _user = value;
                    FixupUser(previousValue);
                }
            }
        }
        private IUser _user;

        #endregion
        #region Association Fixup
    
        private void FixupUser(IUser previousValue)
        {
            if (previousValue != null && previousValue.Bookmark.Contains(this))
            {
                previousValue.Bookmark.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.Bookmark.Contains(this))
                {
                    User.Bookmark.Add(this);
                }
                if (UserId != User.UserId)
                {
                    UserId = User.UserId;
                }
            }
        }

        #endregion
    }
}
