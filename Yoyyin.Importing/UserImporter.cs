using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Data.EntityFramework.Repositories;
using Yoyyin.Model.Importers;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.ValueObjects;
using User = Yoyyin.Model.Users.AggregateRoots.User;
using UserTypes = Yoyyin.Model.Users.Enumerations.UserTypes;

namespace Yoyyin.Importing
{
    public class UserImporter : IUserImporter
    {
        private IUserRepository _repository;

        public UserImporter()
        {
            _repository = new EFUserRepository(new YoyyinEntities1(ConfigurationManager.ConnectionStrings["YoyyinEntities1"].ToString()));
        }

        // Gets user from sql database, converts them to Yoyyin.Model.User
        public IEnumerable<User> Import()
        {
            foreach (Data.User user in _repository.FindAll())
            {
                yield return
                    new User
                        {
                            Active = user.Active != null && (bool) user.Active,
                            Name = user.Name,
                            DisplayName = string.IsNullOrEmpty(user.Alias) ? user.Name : user.Alias,
                            Ideas = new List<Idea>
                                        {
                                            new Idea
                                                {
                                                    Description = user.BusinessDescription,
                                                    Title = user.BusinessTitle,
                                                    CompanyName = user.CompanyName,
                                                    SniHeadID = user.SniHeadID != null ? user.SniHeadID.Trim() : string.Empty,
                                                    SniNo = user.SniNo,
                                                    SearchProfile = new SearchProfile
                                                                        {
                                                                            SearchWords = user.SearchWords != null ? user.SearchWords.Split(new [] { ','}) : new string[0],
                                                                            Competences = user.SearchWordsCompetence != null ? user.SearchWordsCompetence.Split(new [] { ','}) : new string[0],
                                                                            CompetencesNeeded = user.SearchWordsCompetenceNeeded != null ? user.SearchWordsCompetenceNeeded.Split(new [] { ','}) : new string[0],
                                                                            UserTypesNeeded = new UserTypesNeeded
                                                                                                  {
                                                                                                      UserTypeIds = string.IsNullOrEmpty(user.UserTypesNeeded) 
                                                                                                      ? new UserTypes[0]
                                                                                                      : user.UserTypesNeeded
                                                                                                            .Split(new [] { ','})
                                                                                                            .Select(s => (UserTypes)Enum.Parse(typeof(UserTypes), s)) 
                                                                                                  }
                                                                        }
                                                }
                                        },
                            Address = new Address
                                          {
                                              Street = user.Street,
                                              City = user.City,
                                              Phone = user.Phone,
                                              ZipCode = user.ZipCode, 
                                              Coordinate = user.Latitude != null
                                                      ? new Coordinate {Latitude = (double) user.Latitude, Longitude = (double) user.Longitude}
                                                      : new Coordinate()
                                          },
                            Urls = new List<string> { user.Url },
                            CVFileName = user.CVFileName,
                            SniNo = user.SniNo,
                            UserTypeDescription = user.UserTypeDescription,
                            Settings = new Settings
                                           {
                                              ShowAddress = user.ShowAddress,
                                              ShowEmail = user.ShowEmail,
                                              ShowOnMap = user.ShowOnMap
                                           },
                             
                        };
            }
        }
    }
}