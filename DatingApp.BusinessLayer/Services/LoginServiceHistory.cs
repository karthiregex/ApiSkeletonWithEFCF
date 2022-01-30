using DatingApp.BusinessLayer.Interfaces;
using DatingApp.Entities;
using DatingApp.RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BusinessLayer.Services
{
    public class LoginServiceHistory : ILoginHistoryService
    {

        /// <summary>
        /// Creating instance/field of DateRepository and injecting into DateService Constructor
        /// </summary>
        private readonly ILoginHistoryRepo _loginHistoryRepository;

        public LoginServiceHistory(ILoginHistoryRepo loginHistoryRepository)
        {
            _loginHistoryRepository = loginHistoryRepository;
        }

        public List<LoginHistoy> AddloginHistory(LoginHistoy LoginHistoy)
        {
            List<LoginHistoy> loginHistory = new List<LoginHistoy>();
            _loginHistoryRepository.AddLoginHistory(LoginHistoy);
            return loginHistory;
        }

        public void DeleteloginHistory(LoginHistoy LoginHistoy)
        {
            _loginHistoryRepository.DeleteLoginHistory(LoginHistoy);

        }

        public async Task<LoginHistoy> EditloginHistory(LoginHistoy LoginHistoy)
        {
            var result = await _loginHistoryRepository.UpdateLoginHistory(LoginHistoy);
            return result;
        }

        public async Task<LoginHistoy> GetloginHistoryAsync(long id)
        {
            var result = await _loginHistoryRepository.GetLoginHistoryById(id);
            return result;
        }

        LoginHistoy ILoginHistoryService.EditloginHistory(LoginHistoy LoginHistoy)
        {
            throw new NotImplementedException();
        }
    }
}
