﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Models
{
    [Table("users")]
    public partial class User
    {
        [Column("id")]
        public uint Id { get; set; }
        [Required]
        [Column("username", TypeName = "varchar(80)")]
        public string Username { get; set; }
        [Required]
        [Column("email", TypeName = "varchar(254)")]
        public string Email { get; set; }
        [Required]
        [Column("password", TypeName = "varchar(60)")]
        public string Password { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
