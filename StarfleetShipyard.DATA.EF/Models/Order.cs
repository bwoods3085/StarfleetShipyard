using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderShips = new HashSet<OrderShip>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; } = null!;
        public DateTime OrderDate { get; set; }

        public virtual CustomerDetail Customer { get; set; } = null!;
        public virtual ICollection<OrderShip> OrderShips { get; set; }
    }
}
