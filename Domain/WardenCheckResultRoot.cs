﻿using System;

namespace Warden.Services.WardenChecks.Domain
{
    public class WardenCheckResultRoot
    {
        public string UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid WardenId { get; set; }
        public DateTime CreatedAt { get; set; }
        public WardenCheckResult Result { get; set; }
    }
}