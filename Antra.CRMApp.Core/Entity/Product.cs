using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }


        [Required(ErrorMessage = "SupplierId is required")]
        [Column(TypeName = "varchar(50)")]
        public string SupplierId { get; set; }


        [Required(ErrorMessage = "CategoryId is required")]
        [Column(TypeName = "varchar(50)")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "QuantityPerUnit is required")]
        public int QuantityPerUnit { get; set; }


        [Required(ErrorMessage = "UnitPrice is required")]
        public float UnitPrice { get; set; }

        [Required(ErrorMessage = "UnitsInStock is required")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "UnitsOnOrder is required")]
        public int UnitsOnOrder { get; set; }

        [Required(ErrorMessage = "ReorderLevel is required")]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
