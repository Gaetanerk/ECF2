using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECF2.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [Display(Name = "Nom de l'événement")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le lieu est requis")]
        [Display(Name = "Lieu de l'événement")]
        public string Location { get; set; }

        [Required(ErrorMessage = "La date est requise")]
        [Display(Name = "Date de l'événement")]
        public DateOnly Date { get; set; }

        public List<UserEvent> UserEvents { get; set; }

        public Event()
        {
            UserEvents = new List<UserEvent>();
        }
    }
}