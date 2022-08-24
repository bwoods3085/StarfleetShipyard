using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class ShipStatus
    {
        public ShipStatus()
        {
            Ships = new HashSet<Ship>();
        }

        public int ShipStatusId { get; set; }
        public string ShipStatusName { get; set; } = null!;

        public virtual ICollection<Ship> Ships { get; set; }
    }
}
