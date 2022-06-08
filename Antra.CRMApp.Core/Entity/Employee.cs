using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fname is required")]
        [Column(TypeName = "varchar(50)")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Lname is required")]
        [Column(TypeName = "varchar(50)")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }


        [Required(ErrorMessage = "TitleOfCourtesy is required")]
        [Column(TypeName = "varchar(50)")]
        public string TitleOfCourtesy { get; set; }


        [Required(ErrorMessage = "BirthDate is required")]
        [Column(TypeName = "DateTime")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "HireDate is required")]
        [Column(TypeName = "DateTime")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "RegionId is required")]
        public int? RegionId { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }

        [Required(ErrorMessage = "PostalCode is required")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "ReportsTo is required")]
        [Column(TypeName = "varchar(50)")]
        public string ReportsTo { get; set; }

        [Required(ErrorMessage = "PhonePath is required")]
        [Column(TypeName = "varchar(50)")]
        public string PhonePath { get; set; }
    }
}
