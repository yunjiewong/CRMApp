using System;
using System.ComponentModel.DataAnnotations;
using Antra.CRMApp.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Model
{
	public class OrderResponseModel
	{
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        [Required]
        public int quantity { get; set; }
    }
}

