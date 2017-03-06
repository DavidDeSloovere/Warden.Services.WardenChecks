using System;
using System.Collections.Generic;

namespace Warden.Services.WardenChecks.Dto
{
    public class WardenCheckResultDto
    {
        public bool IsValid { get; set; }
        public WatcherCheckResultDto WatcherCheckResult { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public IList<ErrorDto> Errors { get; set; }
    }
}