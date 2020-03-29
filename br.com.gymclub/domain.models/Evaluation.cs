using System;
using System.Collections.Generic;

namespace domain.models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public float anamnese { get; set; }
        public float skinFolds { get; set; }
        public float ergometric { get; set; }
        public int idRegistration { get; set; }
        public int idPhysiotherapist { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Client client { get; set; }

        public Physiotherapist physiotherapist { get; set; }
    }



}