using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace StarfleetShipyard.DATA.EF.Models//.MetaData
{
    [ModelMetadataType(typeof(SupplierMetaData))]
    public partial class Supplier { }

    [ModelMetadataType(typeof(ShipTypeMetaData))]
    public partial class ShipType { }

    [ModelMetadataType(typeof(ShipClassMetaData))]
    public partial class ShipClass { }

    [ModelMetadataType(typeof(ShipStatusMetaData))]
    public partial class ShipStatus { }

    [ModelMetadataType(typeof(ShipMetaData))]
    public partial class Ship { }

    [ModelMetadataType(typeof(OrderMetaData))]
    public partial class Order { }

    [ModelMetadataType(typeof(CustomerDetailMetaData))]
    public partial class CustomerDetail { }

}
