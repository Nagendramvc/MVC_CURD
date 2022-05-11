using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNoteMVC.Models.Validation
{
    public class UserRegistrationValidationClass
    {
            public int UserID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Mobile { get; set; }
    }
}