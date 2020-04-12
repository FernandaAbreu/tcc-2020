using System;
using System.Collections.Generic;

namespace api.models
{
    public class Physiotherapist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int userId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public User User { get; set; }
        public IEnumerable<Evaluation> evaluations { get; set; }
    }
}
