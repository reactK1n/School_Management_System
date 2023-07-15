using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Model.Entities
{
    public class Principal : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
