﻿using System;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Core.Contract.Service
{
	public interface IAccountServiceAsync
	{
		Task<IdentityResult> SignUpAsync(SignupModel model);

		Task<SignInResult> SignInAsync(LoginModel model);
	}
}

