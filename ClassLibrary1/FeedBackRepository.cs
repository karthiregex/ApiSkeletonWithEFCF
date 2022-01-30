using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.DataLayer;
using DatingApp.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatingApp.RepositoryLayer.Interface;

namespace DatingApp.RepositoryLayer
{
    public class FeedBackRepository : IFeedBackRepository
    {
        /// <summary>
        /// Creating and injecting DbContext in DateRepository constructor
        /// </summary>
        private readonly DatingAppDbContext _datingContext;
        public FeedBackRepository(DatingAppDbContext datingDbContext)
        {
            _datingContext = datingDbContext;
        }

        /// <summary>
        /// Able to add a new date datails for an appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<bool> AddFeedBack(FeedBack appointment)
        {
            try
            {
                await _datingContext.FeedBacks.AddAsync(appointment);
                await _datingContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Able to cancel a existing date appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<FeedBack> DeleteFeedBack(FeedBack appointment)
        {
            try
            {
                _datingContext.FeedBacks.Remove(appointment);
                await _datingContext.SaveChangesAsync();
                return await Task.FromResult(appointment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method used to get the date information by the date
        /// </summary>
        /// <param name="DateOfRequest"></param>
        /// <returns></returns>
        public async Task<FeedBack> GetFeedBackByDate(DateTime DateOfRequest)
        {
            try
            {
                var result = await _datingContext.FeedBacks
                    .FirstOrDefaultAsync(h => h.FeedbackDate.Equals(DateOfRequest));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method used to get the date information by the Dateid
        /// </summary>
        /// <param name="dateId"></param>
        /// <returns></returns>
        public async Task<FeedBack> GetFeedBackById(long dateId)
        {
            try
            {
                var result = await _datingContext.FeedBacks
                    .FirstOrDefaultAsync(h => h.FeedbackId.Equals(dateId));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method used to get the date information by the User
        /// </summary>
        /// <param name="RequestSenderName"></param>
        /// <returns></returns>
        public async Task<FeedBack> GetFeedBackByUser(string RequestSenderName)
        {
            try
            {
                var result = await _datingContext.FeedBacks
                    .FirstOrDefaultAsync(h => h.FeedbackDescription.Equals(RequestSenderName));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
        /// <summary>
        /// Method used to update the existing date Request
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<FeedBack> UpdateFeedBack(FeedBack appointment)
        {
            try
            {
                _datingContext.FeedBacks.Update(appointment);
                await _datingContext.SaveChangesAsync();
                return await Task.FromResult(appointment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
