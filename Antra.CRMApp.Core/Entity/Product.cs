using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Antra.CRMApp.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(30)")]
        public string Name { get; set; }

        [Required]
        public int SupplierId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int QuantityPerUnit { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public int UnitsOnOrder { get; set; }
        [Required]
        public int ReorderLevel { get; set; }
        [Required]
        public bool Discontinued { get; set; }


        public Category Category { get; set; }
    }
}
