﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Antra.CRMApp.Core.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required, Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
