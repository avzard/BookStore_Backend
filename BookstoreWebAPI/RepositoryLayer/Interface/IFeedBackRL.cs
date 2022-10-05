using CommonLayer.FeedBackModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedBackRL
    {
        public string AddFeedback(int UserId, FeedBackPostModel feedbackPostModel);
        public List<DisplayFeedback> GetAllFeedback(int bookId);
    }
}
