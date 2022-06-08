﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Entity
{
    public class Shipper
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Phone is required")]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }
    }
}
