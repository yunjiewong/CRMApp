﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.Core.Model
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required, Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required, Column(TypeName = "varchar")]
        [MaxLength(5)]
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(80)]
        public string Address { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string City { get; set; }
        public int RegionId { get; set; }

        public int PostalCode { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Country { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string Phone { get; set; }
        public int? ReportsTo { get; set; }
        [Required, Column(TypeName = "varchar(max)")]
        public string PhotoPath { get; set; }
    }
}
