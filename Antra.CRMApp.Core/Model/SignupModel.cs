﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.Core.Model
{
	public class SignupModel
	{
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

    }
}

