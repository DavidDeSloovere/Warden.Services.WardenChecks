using System;
using Warden.Common.Events;

namespace Warden.Services.WardenChecks.Shared.Events
{
    public class ProcessWardenCheckResultRejected : IRejectedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public string Code { get; }
        public string Reason { get; }

        protected ProcessWardenCheckResultRejected()
        {
        }

        public ProcessWardenCheckResultRejected(Guid requestId, 
            string userId, string code, string reason)
        {
            RequestId = requestId;
            UserId = userId;
            Code = code;
            Reason = reason;
        }
    }
}