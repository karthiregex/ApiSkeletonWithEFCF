using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Entities;

namespace DatingApp.RepositoryLayer.Interface
{
    public interface IFeedBackRepository
    {
        Task<FeedBack> GetFeedBackById(long dateId);
        Task<FeedBack> GetFeedBackByUser(string RequestSenderName);
        Task<FeedBack> GetFeedBackByDate(DateTime DateOfRequest);
        Task<bool> AddFeedBack(FeedBack appointment);
        Task<FeedBack> UpdateFeedBack(FeedBack appointment);
        Task<FeedBack> DeleteFeedBack(FeedBack appointment);
    }
}
