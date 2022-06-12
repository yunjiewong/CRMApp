using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Antra.CRMApp.Core.Entity;

namespace Antra.CRMApp.Core.Model
{
	public class CustomerResponseModel
	{
		public int Id { get; set; }


		[Required, Column(TypeName = "varchar")]
		[MaxLength(30)]
		public string Name { get; set; }

		[Required, Column(TypeName = "varchar")]
		[MaxLength(20)]
		public string City { get; set; }

		public int RegionId { get; set; }
		public Region Region { get; set; }

		[Required, Column(TypeName = "varchar")]
		[MaxLength(15)]
		public string Phone { get; set; }
	}
}

