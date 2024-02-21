using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace silentAPI.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        public string AdharNumber { get; set; }
      
    }
}
