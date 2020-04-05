using System;
namespace viewmodels
{
    public class VMCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int state_id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public VMState state { get; set; }
        
    }
}
