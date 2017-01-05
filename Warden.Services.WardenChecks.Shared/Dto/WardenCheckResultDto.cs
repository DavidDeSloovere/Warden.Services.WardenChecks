﻿using System;
using System.Collections.Generic;

namespace Warden.Services.WardenChecks.Shared.Dto
{
    public class WardenCheckResultDto
    {
        public bool IsValid { get; set; }
        public WatcherCheckResultDto WatcherCheckResult { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public long ExecutionTimeTicks { get; set; }
        public IList<ErrorDto> Errors { get; set; }
    }
}