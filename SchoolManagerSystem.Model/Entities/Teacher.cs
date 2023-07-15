namespace SchoolManagerSystem.Model.Entities
{
    public class Teacher : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
