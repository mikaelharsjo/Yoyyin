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
    public partial class User : IUser
    {
        #region Primitive Properties
    
        public virtual System.Guid UserId
        {
            get { return _userId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_userId != value)
                    {
                        if (aspnet_Users != null && aspnet_Users.UserId != value)
                        {
                            aspnet_Users = null;
                        }
                        _userId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private System.Guid _userId;
    
        public virtual string CompanyName
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Street
        {
            get;
            set;
        }
    
        public virtual string ZipCode
        {
            get;
            set;
        }
    
        public virtual string City
        {
            get;
            set;
        }
    
        public virtual string Phone
        {
            get;
            set;
        }
    
        public virtual string Url
        {
            get;
            set;
        }
    
        public virtual string CVFileName
        {
            get;
            set;
        }
    
        public virtual byte[] Image
        {
            get;
            set;
        }
    
        public virtual string BusinessTitle
        {
            get { return _businessTitle; }
            set { _businessTitle = value; }
        }
        private string _businessTitle = "";
    
        public virtual string BusinessDescription
        {
            get { return _businessDescription; }
            set { _businessDescription = value; }
        }
        private string _businessDescription = "";
    
        public virtual string SniHeadID
        {
            get { return _sniHeadID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_sniHeadID != value)
                    {
                        if (SniHead != null && SniHead.SniHeadID != value)
                        {
                            SniHead = null;
                        }
                        _sniHeadID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _sniHeadID;
    
        public virtual string SniNo
        {
            get { return _sniNo; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_sniNo != value)
                    {
                        if (SniItem != null && SniItem.SniNo != value)
                        {
                            SniItem = null;
                        }
                        _sniNo = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _sniNo;
    
        public virtual string SearchWords
        {
            get;
            set;
        }
    
        public virtual Nullable<double> Latitude
        {
            get;
            set;
        }
    
        public virtual Nullable<double> Longitude
        {
            get;
            set;
        }
    
        public virtual string FacebookID
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> Active
        {
            get;
            set;
        }
    
        public virtual Nullable<int> ForumUserID
        {
            get;
            set;
        }
    
        public virtual string SearchWordsCompetence
        {
            get;
            set;
        }
    
        public virtual string SearchWordsCompetenceNeeded
        {
            get;
            set;
        }
    
        public virtual Nullable<int> UserType
        {
            get;
            set;
        }
    
        public virtual string UserTypesNeeded
        {
            get;
            set;
        }
    
        public virtual string UserTypeDescription
        {
            get;
            set;
        }
    
        public virtual string Alias
        {
            get;
            set;
        }
    
        public virtual string DescEntrepreneur
        {
            get;
            set;
        }
    
        public virtual string DescInnovator
        {
            get;
            set;
        }
    
        public virtual string DescInvestor
        {
            get;
            set;
        }
    
        public virtual string DescFinancing
        {
            get;
            set;
        }
    
        public virtual string DescRetiring
        {
            get;
            set;
        }
    
        public virtual string DescBusinessman
        {
            get;
            set;
        }
    
        public virtual bool ShowEmail
        {
            get;
            set;
        }
    
        public virtual bool ShowAddress
        {
            get;
            set;
        }
    
        public virtual bool ShowOnMap
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ISniHead SniHead
        {
            get { return _sniHead; }
            set
            {
                if (!ReferenceEquals(_sniHead, value))
                {
                    var previousValue = _sniHead;
                    _sniHead = value;
                    FixupSniHead(previousValue);
                }
            }
        }
        private ISniHead _sniHead;
    
        public virtual ISniItem SniItem
        {
            get { return _sniItem; }
            set
            {
                if (!ReferenceEquals(_sniItem, value))
                {
                    var previousValue = _sniItem;
                    _sniItem = value;
                    FixupSniItem(previousValue);
                }
            }
        }
        private ISniItem _sniItem;
    
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
    
        public virtual ICollection<Question> Question
        {
            get
            {
                if (_question == null)
                {
                    var newCollection = new FixupCollection<Question>();
                    newCollection.CollectionChanged += FixupQuestion;
                    _question = newCollection;
                }
                return _question;
            }
            set
            {
                if (!ReferenceEquals(_question, value))
                {
                    var previousValue = _question as FixupCollection<Question>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupQuestion;
                    }
                    _question = value;
                    var newValue = value as FixupCollection<Question>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupQuestion;
                    }
                }
            }
        }
        private ICollection<Question> _question;
    
        public virtual ICollection<Message> Message
        {
            get
            {
                if (_message == null)
                {
                    var newCollection = new FixupCollection<Message>();
                    newCollection.CollectionChanged += FixupMessage;
                    _message = newCollection;
                }
                return _message;
            }
            set
            {
                if (!ReferenceEquals(_message, value))
                {
                    var previousValue = _message as FixupCollection<Message>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMessage;
                    }
                    _message = value;
                    var newValue = value as FixupCollection<Message>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMessage;
                    }
                }
            }
        }
        private ICollection<Message> _message;
    
        public virtual ICollection<Message> Message1
        {
            get
            {
                if (_message1 == null)
                {
                    var newCollection = new FixupCollection<Message>();
                    newCollection.CollectionChanged += FixupMessage1;
                    _message1 = newCollection;
                }
                return _message1;
            }
            set
            {
                if (!ReferenceEquals(_message1, value))
                {
                    var previousValue = _message1 as FixupCollection<Message>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMessage1;
                    }
                    _message1 = value;
                    var newValue = value as FixupCollection<Message>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMessage1;
                    }
                }
            }
        }
        private ICollection<Message> _message1;
    
        public virtual ICollection<Bookmark> Bookmark
        {
            get
            {
                if (_bookmark == null)
                {
                    var newCollection = new FixupCollection<Bookmark>();
                    newCollection.CollectionChanged += FixupBookmark;
                    _bookmark = newCollection;
                }
                return _bookmark;
            }
            set
            {
                if (!ReferenceEquals(_bookmark, value))
                {
                    var previousValue = _bookmark as FixupCollection<Bookmark>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupBookmark;
                    }
                    _bookmark = value;
                    var newValue = value as FixupCollection<Bookmark>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupBookmark;
                    }
                }
            }
        }
        private ICollection<Bookmark> _bookmark;
    
        public virtual ICollection<Comment> Comment
        {
            get
            {
                if (_comment == null)
                {
                    var newCollection = new FixupCollection<Comment>();
                    newCollection.CollectionChanged += FixupComment;
                    _comment = newCollection;
                }
                return _comment;
            }
            set
            {
                if (!ReferenceEquals(_comment, value))
                {
                    var previousValue = _comment as FixupCollection<Comment>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupComment;
                    }
                    _comment = value;
                    var newValue = value as FixupCollection<Comment>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupComment;
                    }
                }
            }
        }
        private ICollection<Comment> _comment;
    
        public virtual ICollection<Comment> Comment1
        {
            get
            {
                if (_comment1 == null)
                {
                    var newCollection = new FixupCollection<Comment>();
                    newCollection.CollectionChanged += FixupComment1;
                    _comment1 = newCollection;
                }
                return _comment1;
            }
            set
            {
                if (!ReferenceEquals(_comment1, value))
                {
                    var previousValue = _comment1 as FixupCollection<Comment>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupComment1;
                    }
                    _comment1 = value;
                    var newValue = value as FixupCollection<Comment>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupComment1;
                    }
                }
            }
        }
        private ICollection<Comment> _comment1;
    
        public virtual ICollection<Visit> Visit
        {
            get
            {
                if (_visit == null)
                {
                    var newCollection = new FixupCollection<Visit>();
                    newCollection.CollectionChanged += FixupVisit;
                    _visit = newCollection;
                }
                return _visit;
            }
            set
            {
                if (!ReferenceEquals(_visit, value))
                {
                    var previousValue = _visit as FixupCollection<Visit>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupVisit;
                    }
                    _visit = value;
                    var newValue = value as FixupCollection<Visit>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupVisit;
                    }
                }
            }
        }
        private ICollection<Visit> _visit;
    
        public virtual ICollection<Visit> Visit1
        {
            get
            {
                if (_visit1 == null)
                {
                    var newCollection = new FixupCollection<Visit>();
                    newCollection.CollectionChanged += FixupVisit1;
                    _visit1 = newCollection;
                }
                return _visit1;
            }
            set
            {
                if (!ReferenceEquals(_visit1, value))
                {
                    var previousValue = _visit1 as FixupCollection<Visit>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupVisit1;
                    }
                    _visit1 = value;
                    var newValue = value as FixupCollection<Visit>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupVisit1;
                    }
                }
            }
        }
        private ICollection<Visit> _visit1;
    
        public virtual Iaspnet_Users aspnet_Users
        {
            get { return _aspnet_Users; }
            set
            {
                if (!ReferenceEquals(_aspnet_Users, value))
                {
                    var previousValue = _aspnet_Users;
                    _aspnet_Users = value;
                    Fixupaspnet_Users(previousValue);
                }
            }
        }
        private Iaspnet_Users _aspnet_Users;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupSniHead(ISniHead previousValue)
        {
            if (previousValue != null && previousValue.User.Contains(this))
            {
                previousValue.User.Remove(this);
            }
    
            if (SniHead != null)
            {
                if (!SniHead.User.Contains(this))
                {
                    SniHead.User.Add(this);
                }
                if (SniHeadID != SniHead.SniHeadID)
                {
                    SniHeadID = SniHead.SniHeadID;
                }
            }
            else if (!_settingFK)
            {
                SniHeadID = null;
            }
        }
    
        private void FixupSniItem(ISniItem previousValue)
        {
            if (previousValue != null && previousValue.User.Contains(this))
            {
                previousValue.User.Remove(this);
            }
    
            if (SniItem != null)
            {
                if (!SniItem.User.Contains(this))
                {
                    SniItem.User.Add(this);
                }
                if (SniNo != SniItem.SniNo)
                {
                    SniNo = SniItem.SniNo;
                }
            }
            else if (!_settingFK)
            {
                SniNo = null;
            }
        }
    
        private void Fixupaspnet_Users(Iaspnet_Users previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.User, this))
            {
                previousValue.User = null;
            }
    
            if (aspnet_Users != null)
            {
                aspnet_Users.User = this;
                if (UserId != aspnet_Users.UserId)
                {
                    UserId = aspnet_Users.UserId;
                }
            }
        }
    
        private void FixupAnswer(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Answer item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Answer item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupQuestion(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Question item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Question item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupMessage(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Message item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Message item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupMessage1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Message item in e.NewItems)
                {
                    item.User1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Message item in e.OldItems)
                {
                    if (ReferenceEquals(item.User1, this))
                    {
                        item.User1 = null;
                    }
                }
            }
        }
    
        private void FixupBookmark(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Bookmark item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Bookmark item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupComment(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Comment item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Comment item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupComment1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Comment item in e.NewItems)
                {
                    item.User1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Comment item in e.OldItems)
                {
                    if (ReferenceEquals(item.User1, this))
                    {
                        item.User1 = null;
                    }
                }
            }
        }
    
        private void FixupVisit(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Visit item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Visit item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupVisit1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Visit item in e.NewItems)
                {
                    item.User1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Visit item in e.OldItems)
                {
                    if (ReferenceEquals(item.User1, this))
                    {
                        item.User1 = null;
                    }
                }
            }
        }

        #endregion
    }
}
