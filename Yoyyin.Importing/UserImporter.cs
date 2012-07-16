using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Data.EntityFramework.Repositories;
using Yoyyin.Model.Importers;
using Yoyyin.Model.Users.AggregateRoots;
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
            foreach (Data.User user in _repository
                                            .FindAll()
                                            .Where(u => u.Name != "" && u.BusinessDescription + u.BusinessTitle != ""))
            {
                yield return
                    new User
                        {
                            UserId = user.UserId,
                            Active = user.Active != null && (bool) user.Active,
                            Name = user.Name,
                            DisplayName = string.IsNullOrEmpty(user.Alias) ? user.Name : user.Alias,
                            HasImage = user.Image != null,
                            Competences = GetCompetences(user),
                            Ideas = new List<Idea>
                                        {
                                            new Idea
                                                {
                                                    Description = user.BusinessDescription,
                                                    Title = user.BusinessTitle,
                                                    CompanyName = user.CompanyName,
                                                    //SniHeadID = user.SniHeadID != null ? user.SniHeadID.Trim() : string.Empty,
                                                    SniNo = user.SniNo != null  ? user.SniNo.Trim() : "Övrigt",
                                                    SniHeadId = user.SniHeadID != null ? user.SniHeadID.Trim() : "Övrigt",
                                                    SearchProfile = new SearchProfile
                                                                        {
                                                                            SearchWords = GetSearchWords(user),
                                                                            //Competences = GetCompetences(user),
                                                                            CompetencesNeeded = GetCompetencesNeeded(user),
                                                                            UserTypesNeeded = new UserTypesNeeded
                                                                                                  {
                                                                                                      UserTypeIds = string.IsNullOrEmpty(user.UserTypesNeeded) 
                                                                                                      ? new int[0]
                                                                                                      : user.UserTypesNeeded
                                                                                                            .Split(new [] { ','})
                                                                                                            .Select(int.Parse) 
                                                                                                            .Select(i => i == 5 ? 1 : i)
                                                                                                            .Distinct()
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
                            UserTypeDescription = user.UserTypeDescription,
                            UserType = user.UserType != null ? (int)user.UserType : (int)UserTypes.Businessman,
                            Settings = new Settings
                                           {
                                              ShowAddress = user.ShowAddress,
                                              ShowEmail = user.ShowEmail,
                                              ShowOnMap = user.ShowOnMap
                                           },
                             
                        };
            }
        }

        private static string[] GetSearchWords(Data.User user)
        {
            return user.SearchWords != null 
                ? user.SearchWords
                        .Split(new[] { ',' }).Select(s => s.ToLower().Trim().Replace(" ", "-").Replace(".", ""))
                        .Where(s => s.Length > 0)
                        .ToArray()
                : new string[0];
        }

        private static string[] GetCompetencesNeeded(Data.User user)
        {
            return user.SearchWordsCompetenceNeeded != null 
                ? user.SearchWordsCompetenceNeeded
                             .Split(new[] { ',' }).Select(s => s.ToLower().Trim().Replace(" ", "-").Replace(".", ""))
                             .Where(s => s.Length > 0)
                             .ToArray()
                : new string[0];
        }

        private static string[] GetCompetences(Data.User user)
        {
            return user.SearchWordsCompetence != null
                       ? user.SearchWordsCompetence
                             .Split(new[] { ',' }).Select(s => s.ToLower().Trim().Replace(" ", "-").Replace(".", "")) //.Replace("5", "1"))
                             .Where(s => s.Length > 0)
                             .ToArray()
                       : new string[0];
        }
    }
}