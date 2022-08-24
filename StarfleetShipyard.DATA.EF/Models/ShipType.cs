using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class ShipType
    {
        public ShipType()
        {
            Ships = new HashSet<Ship>();
        }

        public int ShipTypesId { get; set; }
        public string ShipTypesName { get; set; } = null!;
        public string? ShipTypesDescription { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }
    }
}
