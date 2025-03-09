using System.ComponentModel.DataAnnotations;

namespace RestAPI_SamiHarun_Net24.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Namn { get; set; } = String.Empty;
        public string Beskrivning { get; set; } = String.Empty;

        [Required]
        public string KontaktInfo { get; set; } = String.Empty;

        public List<Utbildning> Utbildningar { get; set; } = new();
        public List<Erfarenhet> Erfarenheter { get; set; } = new();
    }
}
