using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Model
{
	public class ShipperModel
	{
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Enter Name")]
        public string Name { get; set; }
        [Required, Column(TypeName = "varchar(15)")]
        [Display(Name = "Enter Phone")]
        public string Phone { get; set; }
    }
}

