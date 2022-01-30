using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BusinessLayer.Interfaces
{
    public interface ILoginHistoryService
    {
        public Task<LoginHistoy> GetloginHistoryAsync(long id);
        public List<LoginHistoy> AddloginHistory(LoginHistoy LoginHistoy);
        public LoginHistoy EditloginHistory(LoginHistoy LoginHistoy);
        public void DeleteloginHistory(LoginHistoy LoginHistoy);
    }
}
