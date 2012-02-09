using System;
using System.Collections.Generic;

namespace Yoyyin.Domain
{
    public interface ICurrentUser
    {
        Guid UserId { get; set; }
    }

    public class NullUser : IUser
    {
        public Guid UserId
        {
            get { throw new NotImplementedException(); }
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

        public SniHead SniHead
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public SniItem SniItem
        {
            get { throw new NotImplementedException(); }
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

        public int UserType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool Active
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

        public string GetDisplayName()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }
    }

    public interface IUser
    {
        Guid UserId { get; set; }
        string Alias { get; set; }
        string Name { get; set; }
        string City { get; set; }
        string BusinessDescription { get; set; }
        string BusinessTitle { get; set; }
        string SniNo { get; set; }
        string SniHeadID { get; set; }
        SniHead SniHead { get; set; }
        SniItem SniItem { get; set; }
        string Street { get; set; }
        string ZipCode { get; set; }
        double? Latitude { get; set; }
        double? Longitude { get; set; }
        string SearchWords { get; set; }
        string SearchWordsCompetenceNeeded { get; set; }
        string SearchWordsCompetence { get; set; }
        string UserTypesNeeded { get; set; }
        int UserType { get; set; }
        bool Active { get; set; }
        string CompanyName { get; set; }
        string CVFileName { get; set; }
        string DescBusinessman { get; set; }
        string DescEntrepreneur { get; set; }
        string DescFinancing { get; set; }
        string DescInnovator { get; set; }
        string DescInvestor { get; set; }
        string DescRetiring { get; set; }
        string FacebookID { get; set; }
        byte[] Image { get; set; }
        string Phone { get; set; }
        bool ShowAddress { get; set; }
        bool ShowEmail { get; set; }
        bool ShowOnMap { get; set; }
        string Url { get; set; }
        string UserTypeDescription { get; set; }
        string GetDisplayName();
        List<Comment> GetComments();
    }

    public class User : IUser
    {
        public Guid UserId { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string BusinessDescription { get; set; }
        public string BusinessTitle { get; set; }
        
        public string SniNo { get; set; }
        public string SniHeadID { get; set; }
        public SniHead SniHead { get; set; }
        public SniItem SniItem { get; set; }
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

        public string GetDisplayName()
        {
            return string.IsNullOrEmpty(Alias) ? Name : Alias;            
        }

        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }
    }
}