using CommonLayer.FeedBackModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFeedBackBL
    {
        public string AddFeedback(int UserId, FeedBackPostModel feedbackPostModel);

        public List<DisplayFeedback> GetAllFeedback(int bookId);
    }
}
