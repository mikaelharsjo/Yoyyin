using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Users
{
    public class NullUser : IUser
    {
        public Guid UserId
        {
            get { return Guid.Empty; }
            set { throw new NotImplementedException(); }
        }

        public string Alias
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string City
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string BusinessDescription
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string BusinessTitle
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string SniNo
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string SniHeadID
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ISniHead SniHead
        {
            get { return new NoSniHeadSelected(); }
            set { throw new NotImplementedException(); }
        }

        public ISniItem SniItem
        {
            get { return new NoSniItemSelected(); }
            set { throw new NotImplementedException(); }
        }

        public string Street
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string ZipCode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public double? Latitude
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public double? Longitude
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string SearchWords
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string SearchWordsCompetenceNeeded
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string SearchWordsCompetence
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string UserTypesNeeded
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int? UserType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool? Active
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string CompanyName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string CVFileName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string DescBusinessman
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string DescEntrepreneur
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string DescFinancing
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string DescInnovator
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string DescInvestor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string DescRetiring
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string FacebookID
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public byte[] Image
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Phone
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool ShowAddress
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool ShowEmail
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool ShowOnMap
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Url
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string UserTypeDescription
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string UserName { get; set; }

        public string GetDisplayName()
        {
            return "Ingen riktig användare";
        }

        public List<UserComments> GetComments()
        {
            throw new NotImplementedException();
        }

        public string GetProfileUrl()
        {
            return "Ingen riktig användare";
        }
    }
}