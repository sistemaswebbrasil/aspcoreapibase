using Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Models
{
    /// <summary>
    /// User Entity - Users are used to authenticate in the system
    /// </summary>
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
