using System;
using System.Collections.Generic;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Users
{
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
        ISniHead SniHead { get; set; }
        ISniItem SniItem { get; set; }
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
}