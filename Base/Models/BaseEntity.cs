using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Models
{

    public interface ITrackable
    {
        int Id { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        int CreatedBy { get; set; }
        int UpdatedBy { get; set; }
    }
    public abstract class BaseEntity : ITrackable
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("updated_by")]
        public int UpdatedBy { get ; set; }
    }
}
