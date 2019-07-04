using Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Models
{
    public partial class UserDTO : BaseEntity
    {
        private int id;

        [Required]
        public new int Id { get => id; set => id = value; }

        [Required]
        [UsernameUserUnique]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [EmailUserUnique]
        public string Email { get; set; }
    }
}
