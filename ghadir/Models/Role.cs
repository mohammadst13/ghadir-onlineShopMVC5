using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ghadir.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleInSystem { get; set; }


        public int UserId { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}