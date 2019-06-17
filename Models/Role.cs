using System.ComponentModel.DataAnnotations;

namespace Base.Models {
    public class Role {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }

}
