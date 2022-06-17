namespace Lead.Management.Domain.Models
{
    public class InviteCreateModel
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
