namespace domain.models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string anamnese { get; set; }
        public string skinFolds { get; set; }
        public string ergometric { get; set; }
        public int idRegistration { get; set; }
        public int idPhysiotherapist { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<Client> Users { get; set; }

        public Physiotherapist physiotherapist { get; set; }
    }



}