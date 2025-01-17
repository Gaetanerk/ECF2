using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ECF2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Le nom est requis")]
        [DisplayName("Nom d'utilisateur")]
        public string Name { get; set; }
        public List<UserEvent> UserEvents { get; set; }
        public User()
        {
            UserEvents = new List<UserEvent>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
