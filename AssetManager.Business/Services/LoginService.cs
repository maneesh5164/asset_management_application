using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Business.Services
{
    public class LoginService
    {
        private bool _isLoggedIn = false;

        public bool IsLoggedIn => _isLoggedIn;

        public bool Login(string username, string password, IConfiguration config)
        {
            try
            {
                var adminUsername = config["AdminCredentials:Username"];
                var adminPassword = config["AdminCredentials:Password"];

                if (username == adminUsername && password == adminPassword)
                {
                    _isLoggedIn = true;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error during login process.", ex);
            }
        }

        public void Logout()
        {
            _isLoggedIn = false;
        }
    }
}
