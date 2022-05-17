using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Users
{
    public class ChangePasswordModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
