using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Models
{
    [Table("roles")]
    public class Role : BaseEntity
    {
        [Required]
        [Column("description", TypeName = "varchar(80)")]
        public string Description { get; set; }
    }

}
