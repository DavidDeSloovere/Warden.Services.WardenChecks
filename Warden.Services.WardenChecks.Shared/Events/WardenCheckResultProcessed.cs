using System;
using Warden.Common.Events;

namespace Warden.Services.WardenChecks.Shared.Events
{
    public class WardenCheckResultProcessed : IAuthenticatedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public Guid OrganizationId { get; }
        public Guid WardenId { get; }
        public object Result { get; }

        protected WardenCheckResultProcessed()
        {
        }

        public WardenCheckResultProcessed(Guid requestId,
            string userId,
            Guid organizationId,
            Guid wardenId,
            object result)
        {
            RequestId = requestId;
            UserId = userId;
            OrganizationId = organizationId;
            WardenId = wardenId;
            Result = result;
        }
    }
}