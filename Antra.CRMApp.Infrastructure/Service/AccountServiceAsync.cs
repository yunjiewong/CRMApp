﻿using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class AccountServiceAsync: IAccountServiceAsync
	{
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;
        public AccountServiceAsync(IAccountRepositoryAsync accountRepositoryAsync)
        {
            _accountRepositoryAsync = accountRepositoryAsync;
        }

        public async Task<SignInResult> SignInAsync(LoginModel model)
        {
            return await _accountRepositoryAsync.SignIn(model);
        }

        public async Task<IdentityResult> SignUpAsync(SignupModel model)
        {
            return await _accountRepositoryAsync.SignUpAsync(model);

        }

        
    }
}

