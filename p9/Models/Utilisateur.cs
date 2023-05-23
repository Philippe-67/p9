using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace p9.Models
{
    public class Utilisateur

    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Pw{ get; set; }

        public  ICollection<Voiture> ?Voitures { get; set; }
    }
}
