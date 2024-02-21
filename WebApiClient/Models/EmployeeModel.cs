using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiClient.Models
{

    public class EmployeeModel
    {
        [JsonPropertyName("id")]
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [JsonPropertyName("gender")]
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [JsonPropertyName("mobile")]
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        [JsonPropertyName("address")]
        [StringLength(200)]
        public string Address { get; set; }
        [JsonPropertyName("adharNumber")]
        [Required]
        public string AdharNumber { get; set; }
    }
}
