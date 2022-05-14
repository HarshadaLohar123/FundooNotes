using BusinessLayer.Interface;
using DataBaseLayer.Users;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public void AddUser(UserModel user)
        {
            try
            {
                this.userRL.AddUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string LoginUser(string email, string password)
        {
            try
            {
                return this.userRL.LoginUser(email, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
