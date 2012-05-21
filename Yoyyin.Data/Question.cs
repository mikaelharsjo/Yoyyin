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
    public partial class Question : IQuestion
    {
        #region Primitive Properties
    
        public virtual int QuestionID
        {
            get;
            set;
        }
    
        public virtual System.Guid OwnerUserId
        {
            get { return _ownerUserId; }
            set
            {
                if (_ownerUserId != value)
                {
                    if (User != null && User.UserId != value)
                    {
                        User = null;
                    }
                    _ownerUserId = value;
                }
            }
        }
        private System.Guid _ownerUserId;
    
        public virtual int Category
        {
            get;
            set;
        }
    
        public virtual System.DateTime Created
        {
            get;
            set;
        }
    
        public virtual string Text
        {
            get;
            set;
        }
    
        public virtual string Title
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Answer> Answer
        {
            get
            {
                if (_answer == null)
                {
                    var newCollection = new FixupCollection<Answer>();
                    newCollection.CollectionChanged += FixupAnswer;
                    _answer = newCollection;
                }
                return _answer;
            }
            set
            {
                if (!ReferenceEquals(_answer, value))
                {
                    var previousValue = _answer as FixupCollection<Answer>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAnswer;
                    }
                    _answer = value;
                    var newValue = value as FixupCollection<Answer>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAnswer;
                    }
                }
            }
        }
        private ICollection<Answer> _answer;
    
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
            if (previousValue != null && previousValue.Question.Contains(this))
            {
                previousValue.Question.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.Question.Contains(this))
                {
                    User.Question.Add(this);
                }
                if (OwnerUserId != User.UserId)
                {
                    OwnerUserId = User.UserId;
                }
            }
        }
    
        private void FixupAnswer(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Answer item in e.NewItems)
                {
                    item.Question = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Answer item in e.OldItems)
                {
                    if (ReferenceEquals(item.Question, this))
                    {
                        item.Question = null;
                    }
                }
            }
        }

        #endregion
    }
}
