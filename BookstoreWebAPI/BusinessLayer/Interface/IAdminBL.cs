using CommonLayer.AdminModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {
        public string AdminLogin(AdminLoginModel adminLogin);
    }
}
