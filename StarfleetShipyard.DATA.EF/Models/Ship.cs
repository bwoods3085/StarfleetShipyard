using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class Ship
    {
        public Ship()
        {
            OrderShips = new HashSet<OrderShip>();
        }

        public int ShipId { get; set; }
        public string ShipName { get; set; } = null!;
        public decimal? ShipPrice { get; set; }
        public string? ShipDescription { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public int? ShipStatusId { get; set; }
        public int ShipClassesId { get; set; }
        public int ShipTypesId { get; set; }
        public int SupplierId { get; set; }
        public string? ShipImage { get; set; }

        public virtual ShipClass ShipClasses { get; set; } = null!;
        public virtual ShipStatus? ShipStatus { get; set; }
        public virtual ShipType ShipTypes { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<OrderShip> OrderShips { get; set; }
    }
}
