using System;
using System.Collections.Generic;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Ships = new HashSet<Ship>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string? SupplierContact { get; set; }
        public string? City { get; set; }
        public string Planet { get; set; } = null!;
        public string? Sector { get; set; }
        public string? Quadrant { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }
    }
}
