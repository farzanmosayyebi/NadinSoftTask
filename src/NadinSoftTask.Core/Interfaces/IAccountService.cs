﻿using System.Security.Claims;

using NadinSoftTask.Core.Dtos.Security;

namespace NadinSoftTask.Core.Interfaces;

public interface IAccountService
{
    public Task<List<Claim>> Login(UserLoginDto loginDto);
    public Task Register(UserRegisterDto registerDto);
}
