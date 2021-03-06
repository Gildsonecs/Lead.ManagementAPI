using System;

namespace Lead.Management.Domain.Models
{
    public class InvitedModel 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
