using DatingApp.BusinessLayer.Interfaces;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackApiController : ControllerBase
    {
        private readonly IFeedBackService _feedBackServices;
        public FeedBackApiController(IFeedBackService feedbackServices)
        {
            _feedBackServices = feedbackServices;
        }

        [HttpGet]
        [Route("api/GetFeedBacks")]
       
        public IActionResult GetFeedBacks()
        {
            FeedBack feedBack = new FeedBack();
            List<FeedBack> feedbacks = _feedBackServices.AddFeedbacks(feedBack);
            return Ok(feedbacks);
        }
    }
}
