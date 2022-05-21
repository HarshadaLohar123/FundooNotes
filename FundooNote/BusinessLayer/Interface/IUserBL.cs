using DataBaseLayer.Users;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public void AddUser(UserModel user); //method
        public string LoginUser(string email, string password);
        public bool ForgotPassword(string email);
        public bool ChangePassword(string email,ChangePasswordModel changePassword);
        
    }
}
