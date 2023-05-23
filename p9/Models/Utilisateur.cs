namespace p9.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Pw{ get; set; }

        public int VoitureId { get; set; }

        public Voiture? Voiture { get; set; }

    }
}
