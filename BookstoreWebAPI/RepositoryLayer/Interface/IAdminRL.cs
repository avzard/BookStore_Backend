﻿using CommonLayer.AdminModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        public string AdminLogin(AdminLoginModel adminLogin);
    }
}
