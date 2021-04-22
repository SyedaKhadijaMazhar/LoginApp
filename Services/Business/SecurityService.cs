using LoginApp.Models;
using LoginApp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginApp.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoServices = new SecurityDAO();
        public bool Authenticate(UserModel user)
        {
            return daoServices.FindByUser(user);

        }
    }
}