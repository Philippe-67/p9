using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace p9.Models
{
    public class Reparation
    {



        [Key]


        public int Id { get; set; }

        [Required]

        [DataType(DataType.Date)]

        [DisplayName("Date d'intervention")]

        public DateTime DateReparation { get; set; }

        [Required]

        [DisplayName("Type d'intervention")]

        public string TypeIntervention { get; set; }

        [Required]

        [DataType(DataType.Currency)]

        [DisplayName("Coût des réparations")]

        public float CoutReparation { get; set; }

        public int VoitureId { get; set; }

        public Voiture? Voiture { get; set; }

    }
}
