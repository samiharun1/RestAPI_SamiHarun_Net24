using System.ComponentModel.DataAnnotations;

namespace RestAPI_SamiHarun_Net24.Models
{
    public class Utbildning
    {
        public int Id { get; set; }

        [Required]
        public string Skola { get; set; } = String.Empty;

        [Required]
        public string Examen { get; set; } = String.Empty;

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime SlutDatum { get; set; }


        [Required]
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
