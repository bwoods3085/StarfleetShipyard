using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarfleetShipyard.DATA.EF.Models//.MetaData
{
    public class SupplierMetaData
    {
        [Required(ErrorMessage = "* Required Field")]
        [Display(Name = "Supplier")]
        [StringLength(100, ErrorMessage = "* Character limit must not excede 100")]
        public string SupplierName { get; set; } = null!;

        [Display(Name = "Contact")]
        [StringLength(50, ErrorMessage = "* Character limit must not excede 50")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string? SupplierContact { get; set; }

        [StringLength(100, ErrorMessage = "* Character limit must not excede 100")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string? City { get; set; }

        [Required(ErrorMessage = "* Required Field")]
        [StringLength(50, ErrorMessage = "* Character limit must not excede 50")]
        public string Planet { get; set; } = null!;

        [StringLength(50, ErrorMessage = "* Character limit must not excede 50")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string? Sector { get; set; }

        [StringLength(50, ErrorMessage = "* Character limit must not excede 50")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string? Quadrant { get; set; }
    }

    public class ShipTypeMetaData
    {
        [Required(ErrorMessage = "* Required Field")]
        [Display(Name = "Ship Type")]
        [StringLength(75, ErrorMessage = "* Character limit must not excede 75")]
        public string ShipTypesName { get; set; } = null!;

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "* Character limit must not excede 500")]
        [DisplayFormat(NullDisplayText = "No Description")]
        [DataType(DataType.MultilineText)]
        public string? ShipTypesDescription { get; set; }
    }

    public class ShipClassMetaData
    {
        [Required(ErrorMessage = "* Required Field")]
        [Display(Name = "Ship Class")]
        [StringLength(75, ErrorMessage = "* Character limit must not excede 75")]
        public string ShipClassesName { get; set; } = null!;

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "* Character limit must not excede 500")]
        [DisplayFormat(NullDisplayText = "No Description")]
        [DataType(DataType.MultilineText)]
        public string? ShipClassesDescription { get; set; }
    }

    public class ShipStatusMetaData
    {
        [Required(ErrorMessage = "* Required Field")]
        [Display(Name = "Status")]
        [StringLength(75, ErrorMessage = "* Character limit must not excede 75")]
        public string ShipStatusName { get; set; } = null!;
    }

    public class ShipMetaData
    {
        [Required(ErrorMessage = "* Required Field")]
        [Display(Name = "Ship")]
        [StringLength(150, ErrorMessage = "* Character limit must not excede 150")]
        public string ShipName { get; set; } = null!;

        
        [Range(0, (double)decimal.MaxValue)]
        [Display(Name = "Price")]
        public decimal? ShipPrice { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "* Character limit must not excede 500")]
        [DisplayFormat(NullDisplayText = "No Description")]
        [DataType(DataType.MultilineText)]
        public string? ShipDescription { get; set; }

        [Display(Name = "Units In Stock")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [Range(0, (double)decimal.MaxValue)]
        public short? UnitsInStock { get; set; }

        [Display(Name = "Units On Order")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [Range(0, (double)decimal.MaxValue)]
        public short? UnitsOnOrder { get; set; }

        [Display(Name = "Status")]
        public int? ShipStatusId { get; set; }

        [Display(Name = "Class")]
        public int ShipClassesId { get; set; }

        [Display(Name = "Ship Type")]
        public int ShipTypesId { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [Display(Name = "Image")]
        public string? ShipImage { get; set; }
    }

    public class OrderMetaData
    {
        [Display(Name = "Customer")]
        public string CustomerId { get; set; } = null!;

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
    }

    public class CustomerDetailMetaData
    {
        [Required(ErrorMessage = "* Required")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "* Can't excede 50 characters")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "* Can't excede 50 characters")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "* Required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "* Can't excede 100 characters")]
        public string Email { get; set; } = null!;


        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(24, ErrorMessage = "* Must be less than 24 characters")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }


        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(100, ErrorMessage = "* Must be less than 100 characters")]
        public string? Address { get; set; }

        [Display(Name = "Ship Yard")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(150, ErrorMessage = "* Must be less than 150 characters")]
        public string? Shipyard { get; set; }


        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(50, ErrorMessage = "* Must be less than 50 characters")]
        public string City { get; set; } = null!;


        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(2, ErrorMessage = "* Must be less than 2 characters")]
        public string? State { get; set; }


        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(5, ErrorMessage = "* Must be less than 5 characters")]
        [DataType(DataType.PostalCode)]
        public string? Zip { get; set; }


        [Required(ErrorMessage = "* Required")]
        [StringLength(50, ErrorMessage = "* Must be less than 50 characters")]
        public string Planet { get; set; } = null!;


        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(50, ErrorMessage = "* Must be less than 50 characters")]
        public string? Sector { get; set; }


        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(50, ErrorMessage = "* Must be less than 50 characters")]
        public string? Quadrant { get; set; }
    }

}
