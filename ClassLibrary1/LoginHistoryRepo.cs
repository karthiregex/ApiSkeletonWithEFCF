using DatingApp.DataLayer;
using DatingApp.Entities;
using DatingApp.RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.RepositoryLayer
{
    public class LoginHistoryRepo : ILoginHistoryRepo
    {
        /// <summary>
        /// Creating and injecting DbContext in DateRepository constructor
        /// </summary>
        private readonly DatingAppDbContext _datingContext;
        public LoginHistoryRepo(DatingAppDbContext datingDbContext)
        {
            _datingContext = datingDbContext;
        }

        public async Task<bool> AddLoginHistory(LoginHistoy loginHistory)
        {
            try
            {
                await _datingContext.LoginHistoys.AddAsync(loginHistory);
                await _datingContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginHistoy> DeleteLoginHistory(LoginHistoy loginHistory)
        {
            try
            {
                _datingContext.LoginHistoys.Remove(loginHistory);
                await _datingContext.SaveChangesAsync();
                return await Task.FromResult(loginHistory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginHistoy> GetLoginHistoryByDate(DateTime DateOfRequest)
        {
            try
            {
                var result = await _datingContext.LoginHistoys.FirstOrDefaultAsync(h => h.Logintime.Equals(DateOfRequest));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginHistoy> GetLoginHistoryById(long dateId)
        {
            try
            {
                var result = await _datingContext.LoginHistoys
                    .FirstOrDefaultAsync(h => h.LoginTransId.Equals(dateId));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginHistoy> GetLoginHistoryByUser(string RequestSenderName)
        {
            try
            {
                var result = await _datingContext.LoginHistoys
                    .FirstOrDefaultAsync(h => h.LoginUser.Equals(RequestSenderName));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginHistoy> UpdateLoginHistory(LoginHistoy loginHistory)
        {
            try
            {
                _datingContext.LoginHistoys.Update(loginHistory);
                await _datingContext.SaveChangesAsync();
                return await Task.FromResult(loginHistory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
