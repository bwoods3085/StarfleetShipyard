using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class OrderShip
    {
        public int OrderShipsId { get; set; }
        public int ShipId { get; set; }
        public int OrderId { get; set; }
        public short? Quantity { get; set; }
        public decimal? ShipPrice { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Ship Ship { get; set; } = null!;
    }
}
