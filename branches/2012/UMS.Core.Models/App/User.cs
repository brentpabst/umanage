using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UMS.Core.Data.Models.App
{
    public class User
    {
        public Guid UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
