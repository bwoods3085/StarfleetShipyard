using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class CustomerDetail
    {
        public CustomerDetail()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Shipyard { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string Planet { get; set; } = null!;
        public string? Sector { get; set; }
        public string? Quadrant { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
