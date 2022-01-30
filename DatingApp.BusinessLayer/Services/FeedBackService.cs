using DatingApp.BusinessLayer.Interfaces;
using DatingApp.Entities;
using DatingApp.RepositoryLayer.Interface;
using System;
using System.Collections.Generic;

namespace DatingApp.BusinessLayer.Services
{
    public class FeedBackService : IFeedBackService
    {
        /// <summary>
        /// Creating instance/field of DateRepository and injecting into DateService Constructor
        /// </summary>
        private readonly IFeedBackRepository _dateRepository;

        public FeedBackService(IFeedBackRepository dateRepository)
        {
            _dateRepository = dateRepository;
        }

        public List<FeedBack> AddFeedbacks(FeedBack feedBack)
        {
            List<FeedBack> feedBacks = new List<FeedBack>();
            _dateRepository.AddFeedBack(feedBack);
            return feedBacks;
        }

        public void DeleteFeedbacks(FeedBack feedBack)
        {
            throw new NotImplementedException();
        }

        public List<FeedBack> EditFeedbacks(FeedBack feedBack)
        {
            throw new NotImplementedException();
        }

        public List<FeedBack> GetFeedbacks()
        {
            throw new NotImplementedException();
        }
    }
}
