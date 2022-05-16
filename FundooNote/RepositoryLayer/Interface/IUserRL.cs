using DataBaseLayer.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public void AddUser(UserModel user);
        public string LoginUser(string email, string password);
        public bool ForgotPassword(string email);
    }
}
