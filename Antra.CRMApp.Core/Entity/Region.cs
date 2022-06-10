﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Antra.CRMApp.Core.Entity
{
    public class Region
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar"), MaxLength(20)]
        public string Name { get; set; }
    }
}
