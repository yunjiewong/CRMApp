using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Model
{
	public class CategoryModel
	{
		
		public int Id { get; set; }

		[Required, Column(TypeName = "varchar")]
		[MaxLength(20)]
		[Display(Name ="Enter Name")]
		public string Name { get; set; }

		[Required, Column(TypeName = "varchar")]
		[MaxLength(100)]
		[Display(Name = "Enter Description")]
		public string Description { get; set; }
		
	}
}

