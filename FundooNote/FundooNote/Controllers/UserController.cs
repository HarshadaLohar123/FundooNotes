

using BusinessLayer.Interface;
using DataBaseLayer.Users;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.DBContext;
using System;

namespace FundooNote.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserBL userBL;
        FundooContext fundooContext;
        public UserController(IUserBL userBL, FundooContext fundooDBContext)
        {
            this.userBL = userBL;
            this.fundooContext = fundooDBContext;
        }
        [HttpPost("register")]
        public IActionResult AddUser(UserModel user)
        {
            try
            {
                this.userBL.AddUser(user);
                return this.Ok(new { success = true, message = $"Registration Successfull" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
