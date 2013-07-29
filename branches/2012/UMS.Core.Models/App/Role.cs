using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace UMS.Core.Data.Models.App
{
    public class Role
    {
        public Guid RoleId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(75)]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
