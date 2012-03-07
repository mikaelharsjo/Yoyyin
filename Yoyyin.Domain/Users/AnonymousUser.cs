using System;
using System.Collections.Generic;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Users
{
    public class AnonymousUser : IUser
    {
        public Guid UserId { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string BusinessDescription { get; set; }
        public string BusinessTitle { get; set; }
        public string SniNo { get; set; }
        public string SniHeadID { get; set; }
        public ISniHead SniHead { get; set; }
        public ISniItem SniItem { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string SearchWords { get; set; }
        public string SearchWordsCompetenceNeeded { get; set; }
        public string SearchWordsCompetence { get; set; }
        public string UserTypesNeeded { get; set; }
        public int UserType { get; set; }
        public bool Active { get; set; }
        public string CompanyName { get; set; }
        public string CVFileName { get; set; }
        public string DescBusinessman { get; set; }
        public string DescEntrepreneur { get; set; }
        public string DescFinancing { get; set; }
        public string DescInnovator { get; set; }
        public string DescInvestor { get; set; }
        public string DescRetiring { get; set; }
        public string FacebookID { get; set; }
        public byte[] Image { get; set; }
        public string Phone { get; set; }
        public bool ShowAddress { get; set; }
        public bool ShowEmail { get; set; }
        public bool ShowOnMap { get; set; }
        public string Url { get; set; }
        public string UserTypeDescription { get; set; }
        public string UserName { get; set; }
        public string GetDisplayName()
        {
            return "Gäst";
        }

        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public string GetProfileUrl()
        {
            return "#";
        }
    }
}