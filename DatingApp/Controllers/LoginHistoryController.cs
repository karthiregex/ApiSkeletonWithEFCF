using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Services;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    public class LoginHistoryController : Controller
    {
        private readonly ILoginHistoryService _loginHistoryServices;
        public LoginHistoryController(ILoginHistoryService loginHistoryServices)
        {
            _loginHistoryServices = loginHistoryServices;
        }

        [HttpGet]
        [Route("api/GetFeedBacks")]

        public async Task<LoginHistoy> GetFeedBacks(long id)
        {
            LoginHistoy feedBack = new LoginHistoy();
            var feedbacks = await _loginHistoryServices.GetloginHistoryAsync(id);
            return feedbacks;
        }
    }
}
