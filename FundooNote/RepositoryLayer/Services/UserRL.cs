using DataBaseLayer.Users;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.DBContext;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{

    public class UserRL : IUserRL
    {
        FundooContext fundoo;
        public IConfiguration Configuration { get; set; }
        public UserRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.fundoo = fundoo;
            this.Configuration = configuration;
        }
        public void AddUser(UserModel user)
        {
            try
            {
                User userdata = new User();
                userdata.FirstName = user.FirstName;
                userdata.Lastname = user.Lastname;
                userdata.CreatedDate = DateTime.Now;
                userdata.Email = user.Email;
                userdata.Password = user.Password;
                userdata.Address = user.Address;
                fundoo.Add(userdata);
                fundoo.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}