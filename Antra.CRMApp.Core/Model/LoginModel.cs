﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.Core.Model
{
	public class LoginModel
	{
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

