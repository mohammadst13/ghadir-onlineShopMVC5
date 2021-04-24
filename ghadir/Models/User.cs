﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ghadir.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserMail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }


        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}