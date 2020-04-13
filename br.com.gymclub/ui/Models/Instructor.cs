using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.models
{
    public class Instructor
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int userId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [Display(Name = "Usuário")]
        public User User { get; set; }
        public State state { get; set; }
        public City city { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int idCity { get; set; }
        public int idState { get; set; }
        public IEnumerable<Lesson> lessons { get; set; }
    }
}
