using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLib.UserManagment
{
    public class Users
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Required]
        public long Contact { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Address { get; set; }

        public virtual Roles Role { get; set; }
    }
}
