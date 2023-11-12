

namespace TempAPI.Models
{
    public class Measurment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double Temperature { get; set; }
        
        [Required]
        public double Humidity { get; set; }
       
        [Required]
        public double Pressure { get; set; }
        
        [Required]
        public DateTime Time { get; set; }
    }
}
