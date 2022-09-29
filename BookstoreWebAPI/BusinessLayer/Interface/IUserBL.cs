using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserRegistrationModel Register(UserRegistrationModel userModel);
        public string UserLogin(UserLoginModel loginModel);
        public string ForgotPassword(string Email);
        public bool ResetPassword(string Email, string NewPassword, string ConfirmPassword);
    }
}
