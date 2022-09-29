using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL :IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserRegistrationModel Register(UserRegistrationModel userModel)
        {
            try
            {
                return userRL.Register(userModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string UserLogin(UserLoginModel loginModel)
        {
            try
            {
                return userRL.UserLogin(loginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ForgotPassword(string Email)
        {
            try
            {
                return userRL.ForgotPassword(Email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ResetPassword(string Email, string NewPassword, string ConfirmPassword)
        {
            try
            {
                return userRL.ResetPassword(Email, NewPassword, ConfirmPassword);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
