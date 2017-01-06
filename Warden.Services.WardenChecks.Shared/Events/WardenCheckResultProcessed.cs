using System;
using Warden.Common.Events;
using Warden.Services.WardenChecks.Shared.Dto;

namespace Warden.Services.WardenChecks.Shared.Events
{
    public class WardenCheckResultProcessed : IAuthenticatedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public Guid OrganizationId { get; }
        public Guid WardenId { get; }
        public CheckResultDto CheckResult { get; }

        protected WardenCheckResultProcessed()
        {
        }

        public WardenCheckResultProcessed(Guid requestId,
            string userId,
            Guid organizationId,
            Guid wardenId,
            CheckResultDto checkResult)
        {
            RequestId = requestId;
            UserId = userId;
            OrganizationId = organizationId;
            WardenId = wardenId;
            CheckResult = checkResult;
        }
    }
}