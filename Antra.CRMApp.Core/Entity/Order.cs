using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Antra.CRMApp.Core.Entity
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredData { get; set; }

        public DateTime ShippedDate { get; set; }

        public int shipVia { get; set; }



    }
}
