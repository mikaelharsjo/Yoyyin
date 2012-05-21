using System;
using System.Collections.Generic;

namespace Yoyyin.Data.Core.Entities
{
    public interface IUser
    {
        System.Guid UserId { get; set; }
        string CompanyName { get; set; }
        string Name { get; set; }
        string Street { get; set; }
        string ZipCode { get; set; }
        string City { get; set; }
        string Phone { get; set; }
        string Url { get; set; }
        string CVFileName { get; set; }
        byte[] Image { get; set; }
        string BusinessTitle { get; set; }
        string BusinessDescription { get; set; }
        string SniHeadID { get; set; }
        string SniNo { get; set; }
        string SearchWords { get; set; }
        Nullable<double> Latitude { get; set; }
        Nullable<double> Longitude { get; set; }
        string FacebookID { get; set; }
        Nullable<bool> Active { get; set; }
        Nullable<int> ForumUserID { get; set; }
        string SearchWordsCompetence { get; set; }
        string SearchWordsCompetenceNeeded { get; set; }
        Nullable<int> UserType { get; set; }
        string UserTypesNeeded { get; set; }
        string UserTypeDescription { get; set; }
        string Alias { get; set; }
        string DescEntrepreneur { get; set; }
        string DescInnovator { get; set; }
        string DescInvestor { get; set; }
        string DescFinancing { get; set; }
        string DescRetiring { get; set; }
        string DescBusinessman { get; set; }
        bool ShowEmail { get; set; }
        bool ShowAddress { get; set; }
        bool ShowOnMap { get; set; }
        ISniHead SniHead { get; set; }
        ISniItem SniItem { get; set; }
        ICollection<Answer> Answer { get; set; }
        ICollection<Question> Question { get; set; }
        ICollection<Message> Message { get; set; }
        ICollection<Message> Message1 { get; set; }
        ICollection<Bookmark> Bookmark { get; set; }
        ICollection<Comment> Comment { get; set; }
        ICollection<Comment> Comment1 { get; set; }
        ICollection<Visit> Visit { get; set; }
        ICollection<Visit> Visit1 { get; set; }
        Iaspnet_Users aspnet_Users { get; set; }
    }
}