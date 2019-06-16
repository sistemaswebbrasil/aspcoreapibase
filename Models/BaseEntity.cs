using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Models
{

    public interface ITrackable
    {
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }

    }
    public abstract class BaseEntity : ITrackable
    {
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
