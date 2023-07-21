namespace SchoolManagerSystem.Model.Entities
{
	public class Address : BaseEntity
	{
		public string State { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string PostalCode { get; set; }
	}
}
