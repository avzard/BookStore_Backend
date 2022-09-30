using BusinessLayer.Interface;
using CommonLayer.AdminModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public string AdminLogin(AdminLoginModel adminLogin)
        {
            try
            {
                return adminRL.AdminLogin(adminLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
