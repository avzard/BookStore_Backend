using BusinessLayer.Interface;
using CommonLayer.FeedBackModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BookstoreWebAPI.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class FeedBackController : Controller
    {
        IFeedBackBL feedBackBL;
        public FeedBackController(IFeedBackBL feedbackBL)
        {
            this.feedBackBL = feedbackBL;
        }
        [HttpPost("AddFeedBack")]
        public IActionResult AddFeedBack(FeedBackPostModel feedBackPostModel)
        {
            int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

            var result = this.feedBackBL.AddFeedback(UserID, feedBackPostModel);
            if (result != null)
            {
                return this.Ok(new { success = true, message = " Feedback Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "FeedBack is Unsuccessfull", });
            }
        }
        [HttpGet("GetAllFeedback")]
        public IActionResult GetAllFeedback(int bookId)
        {

            var result = this.feedBackBL.GetAllFeedback(bookId);
            if (result != null)
            {
                return this.Ok(new { success = true, message = " Feedback Get Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "FeedBack Not Found", });
            }
        }
    }
}
