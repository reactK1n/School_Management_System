using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagerSystem.Model.Entities
{
	public class Principal : BaseEntity
	{
		[ForeignKey("User")]
		public string UserId { get; set; }

		public string AddressId { get; set; }

		//navigation properties
		public Address Address { get; set; }

		public ApplicationUser User { get; set; }
	}
}
