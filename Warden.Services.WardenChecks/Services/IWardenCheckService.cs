﻿using System;
using Warden.Common.Types;
using Warden.Services.WardenChecks.Domain;

namespace Warden.Services.WardenChecks.Services
{
    public interface IWardenCheckService
    {
        Maybe<CheckResult> ValidateAndParseResult(string userId,
            Guid organizationId, Guid wardenId, object checkResult, DateTime createdAt);
    }
}