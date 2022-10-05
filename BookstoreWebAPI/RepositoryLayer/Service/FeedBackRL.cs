using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CommonLayer.FeedBackModel;

namespace RepositoryLayer.Service
{
    public class FeedBackRL : IFeedBackRL
    {
        private readonly string connetionString;
        public FeedBackRL(IConfiguration configuration)
        {
            connetionString = configuration.GetConnectionString("StoreBook");
        }
        public static string connectionstring = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BookStoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly SqlConnection connection = new SqlConnection(connectionstring);
        public string AddFeedback(int UserId, FeedBackPostModel feedbackPostModel)
        {
            using (connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spAddFeedBack", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@Comment", feedbackPostModel.Comment);
                    cmd.Parameters.AddWithValue("@BookId", feedbackPostModel.BookId);
                    cmd.Parameters.AddWithValue("@TotalRating", feedbackPostModel.TotalRating);

                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return "Added";
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<DisplayFeedback> GetAllFeedback(int bookId)
        {
            using (connection)
            {
                List<DisplayFeedback> displayFeedbacks = new List<DisplayFeedback>();
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetFeedback", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DisplayFeedback display = new DisplayFeedback();
                        display.FullName = Convert.ToString(reader["FullName"]);
                        display.Comment = Convert.ToString(reader["Comments"]);
                        display.BookId = Convert.ToInt32(reader["BookId"]);
                        display.TotalRating = Convert.ToInt32(reader["TotalRating"]);
                        display.FeedbackId = Convert.ToInt32(reader["FeedbackId"]);

                        displayFeedbacks.Add(display);
                    }
                    connection.Close();

                    if (displayFeedbacks.Count > 0)
                    {
                        return displayFeedbacks;
                    }
                    else
                    {
                        return null;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
