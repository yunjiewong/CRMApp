﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Entity
{
	public class Region
	{
		
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[Column(TypeName = "varchar(50)")]
		public string Name { get; set; }
		
	}
}

