using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Entity
{
    public class Order
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

       [Required, Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal  Discount { get; set; }
        [Required]
        public int quantity { get; set; }

    }
}
