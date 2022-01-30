using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.BusinessLayer.Interfaces
{
    public interface IFeedBackService
    {
        public List<FeedBack> GetFeedbacks();
        public List<FeedBack> AddFeedbacks(FeedBack feedBack);
        public List<FeedBack> EditFeedbacks(FeedBack feedBack);
        public void DeleteFeedbacks(FeedBack feedBack);
    }
}
