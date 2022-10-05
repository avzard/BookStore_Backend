using BusinessLayer.Interface;
using CommonLayer.FeedBackModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedBackBL : IFeedBackBL
    {
        IFeedBackRL feedBackRL;
        public FeedBackBL(IFeedBackRL feedBackRL)
        {
            this.feedBackRL = feedBackRL;
        }
        public string AddFeedback(int UserId, FeedBackPostModel feedbackPostModel)
        {
            try
            {
                return this.feedBackRL.AddFeedback(UserId, feedbackPostModel);
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }

        public List<DisplayFeedback> GetAllFeedback(int bookId)
        {
            try
            {
                return this.feedBackRL.GetAllFeedback(bookId);
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
    }
}
