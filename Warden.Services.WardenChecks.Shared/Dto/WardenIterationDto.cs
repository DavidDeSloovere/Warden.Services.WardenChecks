using System;
using System.Collection.Generic;

namespace Warden.Services.WardenChecks.Shared.Dto
{
    public class WardenIterationDto
    {
        public Guid Id { get; set; }
        public string WardenName { get; set; }
        public long Ordinal { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public bool IsValid { get; set; }
        public IList<WardenCheckResultDto> Results { get; set; }
    }
}