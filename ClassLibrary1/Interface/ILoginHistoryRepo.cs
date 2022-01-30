using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.RepositoryLayer.Interface
{
    public interface ILoginHistoryRepo
    {
        Task<LoginHistoy> GetLoginHistoryById(long dateId);
        Task<LoginHistoy> GetLoginHistoryByUser(string RequestSenderName);
        Task<LoginHistoy> GetLoginHistoryByDate(DateTime DateOfRequest);
        Task<bool> AddLoginHistory(LoginHistoy appointment);
        Task<LoginHistoy> UpdateLoginHistory(LoginHistoy appointment);
        Task<LoginHistoy> DeleteLoginHistory(LoginHistoy appointment);
    }
}
