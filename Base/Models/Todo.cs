using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Models
{
    /// <summary>
    /// Entity Todo - Tasks to be executed
    /// </summary>
    [Table("todos")]
    public class Todo : BaseEntity
    {
        [Required]
        [Column("name", TypeName = "varchar(80)")]
        public string Name { get; set; }

        [Column("description", TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Column("IsComplete", TypeName = "bit")]
        public bool IsComplete { get; set; }
    }
}
