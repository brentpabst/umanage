using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.App
{
    public class Employee
    {
        public Guid UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
