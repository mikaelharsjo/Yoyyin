﻿using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;

        // avoid this, instead inject repository
        public UserService()
        {
            _userRepository = new EntityUserRepository(new YoyyinEntities1());
        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserService(IUserRepository userRepository, ICurrentUser currentUser)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public IUser CreateUser(Data.User user)
        {
            if (user == null) return new NullUser();

            return new User
                       {
                           BusinessDescription = user.BusinessDescription,
                           Latitude = user.Latitude,
                           Longitude = user.Longitude,
                           BusinessTitle = user.BusinessTitle,
                           City = user.City,
                           Street = user.Street,
                           SniNo = user.SniNo,
                           Alias = user.Alias,
                           Active = user.Active != null && (bool)user.Active,
                           Name = user.Name,
                           CVFileName = user.CVFileName
                       }; // not done
        }

        public IEnumerable<IUser> SearchAdvanced(string text, bool isEntrepreneur, bool isInnovator, bool isInvestor, string sniNo)
        {
            return _userRepository.Find().Select(CreateUser);
            //if (isEntrepreneur)
            //    users = users.FindAll(x => x.UserType != null && (int)x.UserType == (int)UserTypes.Entrepreneur).ToList();
            //if (isInnovator)
            //    users = useu.FindAll(x => x.UserType != null && (int)x.UserType == (int)UserTypes.Innovator).ToList();
            //if (isInvestor)
            //    users = users.FindAll(x => x.UserType != null && (int)x.UserType == (int)UserTypes.Investor).ToList();

            //if (sniNo != "0")
            //    users = users.FindAll(x => x.SniHeadID == sniNo);

            //if (!String.IsNullOrEmpty(text))
            //    users = users.FindAll(x => (x.Name.Contains(text) || x.BusinessDescription.Contains(text)));


        }

        public IEnumerable<IUser> SearchQuick(string textToMatch)
        {
            return
                _userRepository
                        .Find()
                        .Where(
                            user =>
                            user.SearchWordsCompetence.Contains(textToMatch) || user.BusinessDescription.Contains(textToMatch) ||
                            user.City.Contains(textToMatch) || user.Street.Contains(textToMatch) ||
                            user.ZipCode.Contains(textToMatch) || user.BusinessTitle.Contains(textToMatch) ||
                            user.Name.Contains(textToMatch) || user.SearchWords.Contains(textToMatch) ||
                            user.SniHead.Title.Contains(textToMatch) ||
                            user.SniItem.Title.Contains(textToMatch) && user.Active == true)
                        .Select(CreateUser);
        }



        public IEnumerable<User> GetLastActiveUsersWithImage()
        {
            throw new NotImplementedException();
            //return _userRepository.Find().Where(user =>    ).OrderBy(User => User. orderby x.aspnet_Users.LastActivityDate descending where x.Image != null select x);
        }

        public IEnumerable<IUser> GetAllUsersIncludingSni()
        {
            return _userRepository
                        .GetAllUsersIncludingSni()
                        .Select(CreateUser)
                        .AsEnumerable();
        }

        public IEnumerable<Guid> GetUserIDsWithMostVisits()
        {
            return _userRepository.GetUserIDsWithMostVisits();
        }

        public int GetNumberOfUsers()
        {
            return _userRepository.GetNumberOfUsers();
        }

        public IEnumerable<IUser> GetUsersBySni(string sniHeadID)
        {
            return _userRepository.Find().Where(user => user.SniHeadID == sniHeadID).Select(CreateUser);
        }

        public void DeleteUser(Guid userId)
        {
            _userRepository.Delete(new Data.User() {UserId = userId});
        }

        public void Save(IUser user)
        {
            throw new NotImplementedException();
            //using (var entities = new YoyyinEntities1())
            //{
            //    Data.User userToSave = entities.User.First(x => x.UserId == user.UserId);

            //    userToSave.ZipCode = user.ZipCode;
            //    userToSave.Active = user.Active;
            //    userToSave.Alias = user.Alias;
            //    userToSave.BusinessDescription = user.BusinessDescription;
            //    userToSave.BusinessTitle = user.BusinessTitle;
            //    userToSave.City = user.City;
            //    userToSave.CompanyName = user.CompanyName;
            //    userToSave.CVFileName = user.CVFileName;
            //    userToSave.DescBusinessman = user.DescBusinessman;
            //    userToSave.DescEntrepreneur = user.DescEntrepreneur;
            //    userToSave.DescFinancing = user.DescFinancing;
            //    userToSave.DescInnovator = user.DescInnovator;
            //    userToSave.DescInvestor = user.DescInvestor;
            //    userToSave.DescRetiring = user.DescRetiring;
            //    userToSave.FacebookID = user.FacebookID;
            //    userToSave.Image = user.Image;
            //    userToSave.Latitude = user.Latitude;
            //    userToSave.Longitude = user.Longitude;
            //    userToSave.Name = user.Name;
            //    userToSave.Phone = user.Phone;
            //    userToSave.SearchWords = user.SearchWords;
            //    userToSave.SearchWordsCompetence = user.SearchWordsCompetence;
            //    userToSave.SearchWordsCompetenceNeeded = user.SearchWordsCompetenceNeeded;
            //    userToSave.ShowAddress = user.ShowAddress;
            //    userToSave.ShowEmail = user.ShowEmail;
            //    userToSave.ShowOnMap = user.ShowOnMap;
            //    userToSave.SniHeadID = user.SniHeadID;
            //    userToSave.SniNo = user.SniNo;
            //    userToSave.Street = user.Street;
            //    userToSave.Url = user.Url;
            //    userToSave.UserType = user.UserType;
            //    userToSave.UserTypeDescription = user.UserTypeDescription;
            //    userToSave.UserTypesNeeded = user.UserTypesNeeded;

            //    entities.SaveChanges();
            //}
        }

        public void CreateUserInDb(IUser user)
        {
            _userRepository.Add(new Data.User() {Active = user.Active}); // TODO all properties must be set
            _userRepository.Save();
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            // we wan´t to enumerate here so we can dispose the ObjectContext instance
            return _userRepository
                        .Find()
                        .Select(CreateUser); // User.Include("SniHead").Include("SniItem");
        }

        public IEnumerable<IUser> GetUsersWithSniHeadOf(string sniHead)
        {
            return _userRepository
                        .Find()
                        .Where(user => user.SniHeadID == sniHead)
                        .Select(CreateUser);
        }

        public IUser GetUser(Guid userId)
        {
            return _userRepository
                .Find()
                .Where(u => u.UserId == userId)
                .Select(CreateUser)
                .First();
        }

        public IUser GetCurrentUser()
        {
            return GetUser(_currentUser.UserId);
        }

        public void RemoveImage(IUser user)
        {
            user.Image = null;
            Save(user);
        }

        public void RemoveCv(IUser user)
        {
            user.CVFileName = string.Empty;
            Save(user);
        }

        public void InActivateUser(IUser user)
        {
            user.Active = false;
            Save(user);
        }
    }
}
