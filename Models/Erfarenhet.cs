using System.ComponentModel.DataAnnotations;

namespace RestAPI_SamiHarun_Net24.Models
{
    public class Erfarenhet
    {
        public int Id { get; set; }

        [Required]
        public string JobTitel { get; set; } = String.Empty;

        [Required]
        public string Företag { get; set; } = String.Empty;

        [Required]
        public int År { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
