using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Base.Models
{
    [Table("users")]
    public partial class User : BaseEntity
    {
        [Required]
        [UsernameUserUnique]
        [Column("username", TypeName = "varchar(80)")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [EmailUserUnique]
        [Column("email", TypeName = "varchar(254)")]
        public string Email { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(60)")]
        public string Password { get; set; }

    }
}
