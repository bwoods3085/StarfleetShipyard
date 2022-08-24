using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class ShipClass
    {
        public ShipClass()
        {
            Ships = new HashSet<Ship>();
        }

        public int ShipClassesId { get; set; }
        public string ShipClassesName { get; set; } = null!;
        public string? ShipClassesDescription { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }
    }
}
