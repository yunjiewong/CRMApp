﻿using System;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Core.Contract.Repository
{
	public interface IAccountRepositoryAsync:IRepositoryAsync<SignupModel>
	{
		Task<IdentityResult> SignUpAsync(SignupModel model);

		Task<SignInResult> SignIn(LoginModel login);
	}
}

